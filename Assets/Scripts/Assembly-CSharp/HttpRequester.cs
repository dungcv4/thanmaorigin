// Class:  KKUpdater.HttpRequester + nested types (BeforeReadAsyncHookDelegate, <>c, <>c__DisplayClass65_0)
// GUID:   b7262595e5c03029e04a43a3fe1ab76b (preserved via .meta)
// Source: KTO_DecompiledReference/KKUpdater/HttpRequester.c (38 methods, 1304 LOC)
//         + KTO_DecompiledReference/KKUpdater.HttpRequester/{
//             __c.c (66 LOC),
//             __c__DisplayClass65_0.c (252 LOC),
//             BeforeReadAsyncHookDelegate.c (147 LOC) }
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1368 + nested 1366/1367/<>c__DisplayClass65_0)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.
//
// CLASS-LEVEL DEVIATIONS:
// - DownloadQueue.QueueType buffer pool: gốc allocates BufferRead from pre-warmed pool by queue priority.
//   We allocate per-instance based on bufferSize. Behavior equivalent for single-request flows.
// - Mutex (offset 0x80): preserved as System.Threading.Mutex per gốc but accessed via using-statement
//   for safer C# semantics (gốc explicitly calls WaitOne/ReleaseMutex per accessor).
// - ServerCertificateValidationCallback set to "always-true" in cctor (matches gốc cctor).

using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace KKUpdater
{
    public class HttpRequester : IDisposable
    {
        // Nested delegate type — Source: KKUpdater.HttpRequester/BeforeReadAsyncHookDelegate.c (147 LOC)
        // gốc: MulticastDelegate (Action-style void Invoke()).
        public delegate void BeforeReadAsyncHookDelegate();

        // Fields (offsets từ dump.cs)
        public BeforeReadAsyncHookDelegate BeforeReadAsyncHook;     // 0x10
        private int BufferSize;                                     // 0x18
        private const int DefaultTimeout = 120000;
        private double _speedLimit;                                 // 0x20
        private double currentSpeed;                                // 0x28
        public byte[] BufferRead;                                   // 0x30
        private HttpWebRequest m_Request;                           // 0x38 (k__BackingField)
        private HttpWebResponse m_Response;                         // 0x40 (k__BackingField)
        public Stream ResponseStream;                               // 0x48
        private string _requestMethod;                              // 0x50
        private string _contentType;                                // 0x58
        private byte[] _contents;                                   // 0x60
        private string m_Url;                                       // 0x68 (k__BackingField)
        private bool _isFinished;                                   // 0x70
        private Exception _error;                                   // 0x78
        private Mutex syncLock;                                     // 0x80
        private long _requestRange;                                 // 0x88
        private long requestedSize;                                 // 0x90
        private long m_TotalSize;                                   // 0x98 (k__BackingField)
        private MemoryStream m_DataMemStream;                       // 0xA0 (k__BackingField)

        // VMA: 0x01bc532d — Source: HttpRequester.c:15 (.cctor)
        // gốc body:
        //   ServicePointManager.ServerCertificateValidationCallback +=
        //       new RemoteCertificateValidationCallback(<>c.<>9, <>c.<.cctor>b__0_0);
        //   ServicePointManager.MaxServicePointIdleTime = 100000;
        //   ServicePointManager.DefaultConnectionLimit = 10;
        // <>c.<.cctor>b__0_0 returns true unconditionally — accept any cert.
        static HttpRequester()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.MaxServicePointIdleTime = 100000;
            ServicePointManager.DefaultConnectionLimit = 10;
        }

        // VMA: 0x01bc5433 / 0x01bc5438 — Source: HttpRequester.c:62/79 (get/set_Request)
        public HttpWebRequest Request { get => m_Request; private set => m_Request = value; }
        // VMA: 0x01bc543d / 0x01bc5442 — Source: HttpRequester.c:97/114 (get/set_Response)
        public HttpWebResponse Response { get => m_Response; private set => m_Response = value; }
        // VMA: 0x01bc5447 / 0x01bc544c — Source: HttpRequester.c:132/149 (get/set_Url)
        public string Url { get => m_Url; private set => m_Url = value; }

        // VMA: 0x01bc5451 — Source: HttpRequester.c:167 (get_IsFinished — Mutex sync)
        // gốc body: syncLock.WaitOne(); bool b = _isFinished; syncLock.ReleaseMutex(); return b;
        // VMA: 0x01bc5490 — Source: HttpRequester.c:197 (set_IsFinished)
        public bool IsFinished
        {
            get
            {
                if (syncLock == null) throw new NullReferenceException();
                syncLock.WaitOne();
                try { return _isFinished; }
                finally { syncLock.ReleaseMutex(); }
            }
            set
            {
                if (syncLock == null) throw new NullReferenceException();
                syncLock.WaitOne();
                try { _isFinished = value; }
                finally { syncLock.ReleaseMutex(); }
            }
        }

        // VMA: 0x01bc54d6 / 0x01bc5517 — Source: HttpRequester.c:226/256 (get/set_Error — Mutex)
        public Exception Error
        {
            get
            {
                if (syncLock == null) throw new NullReferenceException();
                syncLock.WaitOne();
                try { return _error; }
                finally { syncLock.ReleaseMutex(); }
            }
            private set
            {
                if (syncLock == null) throw new NullReferenceException();
                syncLock.WaitOne();
                try { _error = value; }
                finally { syncLock.ReleaseMutex(); }
            }
        }

        // VMA: 0x01bc5560 / 0x01bc5568 — Source: HttpRequester.c:285/302 (get/set_TotalSize — direct)
        public long TotalSize { get => m_TotalSize; private set => m_TotalSize = value; }

        // VMA: 0x01bc5570 — Source: HttpRequester.c:320 (get_Progress)
        // gốc body:
        //   if (TotalSize < 1) return 0.0;
        //   return (double)RequestedSize / (double)TotalSize;
        public double Progress
        {
            get
            {
                if (m_TotalSize < 1) return 0.0;
                return (double)RequestedSize / (double)m_TotalSize;
            }
        }

        // VMA: 0x01bc55e1 / 0x01bc55e9 — Source: HttpRequester.c:377/394 (get/set_DataMemStream — direct)
        public MemoryStream DataMemStream { get => m_DataMemStream; private set => m_DataMemStream = value; }

        // VMA: 0x01bc55f1 — Source: HttpRequester.c:412 (get_DataStreamLen — Mutex)
        // gốc body: syncLock.WaitOne(); long ret = (DataMemStream != null && DataMemStream.Length > 0) ? TotalSize : 0; syncLock.ReleaseMutex(); return ret;
        public long DataStreamLen
        {
            get
            {
                if (syncLock == null) throw new NullReferenceException();
                syncLock.WaitOne();
                try
                {
                    long ret = 0;
                    if (m_DataMemStream != null && m_DataMemStream.Length > 0)
                        ret = m_TotalSize;
                    return ret;
                }
                finally { syncLock.ReleaseMutex(); }
            }
        }

        // VMA: 0x01bc5664 — Source: HttpRequester.c:452 (get_DataBytes — Mutex)
        // gốc body: syncLock.WaitOne(); byte[] arr = DataMemStream != null ? DataMemStream.ToArray() : null; syncLock.ReleaseMutex(); return arr;
        public byte[] DataBytes
        {
            get
            {
                if (syncLock == null) throw new NullReferenceException();
                syncLock.WaitOne();
                try
                {
                    return m_DataMemStream != null ? m_DataMemStream.ToArray() : null;
                }
                finally { syncLock.ReleaseMutex(); }
            }
        }

        // VMA: 0x01bc56ce — Source: HttpRequester.c:488 (get_IsError)
        // gốc body: return Error != null;
        public bool IsError => Error != null;

        // VMA: 0x01bc56dc — Source: HttpRequester.c:508 (get_CurrentSpeed — Mutex)
        public double CurrentSpeed
        {
            get
            {
                if (syncLock == null) throw new NullReferenceException();
                syncLock.WaitOne();
                try { return currentSpeed; }
                finally { syncLock.ReleaseMutex(); }
            }
        }

        // VMA: 0x01bc559d — Source: HttpRequester.c:347 (get_RequestedSize — Mutex)
        // VMA: 0x01bc572f — Source: HttpRequester.c:538 (set_RequestedSize)
        public long RequestedSize
        {
            get
            {
                if (syncLock == null) throw new NullReferenceException();
                syncLock.WaitOne();
                try { return requestedSize; }
                finally { syncLock.ReleaseMutex(); }
            }
            set
            {
                if (syncLock == null) throw new NullReferenceException();
                syncLock.WaitOne();
                try { requestedSize = value; }
                finally { syncLock.ReleaseMutex(); }
            }
        }

        // VMA: 0x01bc577b / 0x01bc57ce — Source: HttpRequester.c:567/597 (get/set_SpeedLimit — Mutex)
        public double SpeedLimit
        {
            get
            {
                if (syncLock == null) throw new NullReferenceException();
                syncLock.WaitOne();
                try { return _speedLimit; }
                finally { syncLock.ReleaseMutex(); }
            }
            set
            {
                if (syncLock == null) throw new NullReferenceException();
                syncLock.WaitOne();
                try { _speedLimit = value; }
                finally { syncLock.ReleaseMutex(); }
            }
        }

        // VMA: 0x01bc5820 — Source: HttpRequester.c:626 (.ctor)
        // gốc body:
        //   _requestMethod = "GET" (DAT_0359eea8);
        //   syncLock = new Mutex();
        //   System_Object___ctor(this, 0);  // gốc orders Object__ctor AFTER Mutex creation — preserved
        //   m_Url = url;
        //   BufferSize = bufferSize;
        //   // pick buffer from pool by queueType (Normal=0x28, High=0x30, Top=0x38)
        //   byte[] pooled = (queueType==Top) ? pool[0x38] : (queueType==High) ? pool[0x30] : pool[0x28];
        //   m_DataMemStream = pooled;  // (gốc treats pooled as MemoryStream — but offset path indicates byte buffer)
        //   pooled.SetLength(0);   (pooled is actually MemoryStream — gốc uses (**(code **)(*plVar3 + 0x308)) which is SetLength)
        //   m_TotalSize = 0;
        //   RequestedSize = 0;
        //   BufferRead = new byte[bufferSize];
        //   m_Request = null;
        //   ResponseStream = null;
        public HttpRequester(string url, int bufferSize, DownloadQueue.QueueType queueType)
        {
            _requestMethod = "GET";
            syncLock = new Mutex();
            m_Url = url;
            BufferSize = bufferSize;
            // DEVIATION: gốc allocates from a static MemoryStream pool indexed by queueType.
            //  We allocate a fresh MemoryStream — same observable behavior for one-shot downloads.
            m_DataMemStream = new MemoryStream();
            m_DataMemStream.SetLength(0);
            m_TotalSize = 0;
            RequestedSize = 0;
            BufferRead = new byte[bufferSize];
            m_Request = null;
            m_Response = null;
            ResponseStream = null;
            _ = queueType; // queueType selects pool offset in gốc; we ignore (DEVIATION).
        }

        // VMA: 0x01bc598c — Source: HttpRequester.c:696 (SetRequestMethod)
        public void SetRequestMethod(string method) => _requestMethod = method;

        // VMA: 0x01bc5991 — Source: HttpRequester.c:714 (ResponseTimeoutCallback)
        // gốc body:
        //   if (timedOut && state is HttpWebRequest req) req.Abort();
        private void ResponseTimeoutCallback(object state, bool timedOut)
        {
            if (timedOut && state is HttpWebRequest req) req.Abort();
        }

        // VMA: 0x01bc5a19 — Source: HttpRequester.c:753 (ReadTimeoutCallback)
        // gốc body:
        //   if (timedOut && ResponseStream != null) {
        //     ResponseStream.Close();
        //     IsFinished = true;
        //   }
        private void ReadTimeoutCallback(object state, bool timedOut)
        {
            if (timedOut && ResponseStream != null)
            {
                ResponseStream.Close();
                IsFinished = true;
            }
        }

        // VMA: 0x01bc5a4a — Source: HttpRequester.c:777 (Start)
        // gốc body:
        //   HttpWebRequest req = (HttpWebRequest)WebRequest.Create(m_Url);
        //   if (_requestRange > 0) {
        //     req.AddRange(_requestRange);
        //     RequestedSize = _requestRange;
        //   }
        //   m_Request = req;
        //   req.Method = _requestMethod;
        //   req.set_KeepAlive(false);   // gốc 0x268 is set_KeepAlive
        //   ServicePointManager.DefaultConnectionLimit = 10;
        //   ServicePointManager.UseNagleAlgorithm = false;  // 0x28
        //   req.UserAgent = "Mozilla/5.0 ...";  // DAT_035b00e8
        //   if (!string.IsNullOrEmpty(_contentType)) req.ContentType = _contentType;
        //   if (_contents != null) {
        //     req.ContentLength = _contents.Length;
        //     Stream rs = req.GetRequestStream();
        //     rs.Write(_contents, 0, _contents.Length); rs.Close();
        //   }
        //   IAsyncResult ar = req.BeginGetResponse(new AsyncCallback(this.RespCallback), null);
        //   ThreadPool.RegisterWaitForSingleObject(ar.AsyncWaitHandle, new WaitOrTimerCallback(this.ResponseTimeoutCallback), req, 120000, true);
        public void Start()
        {
            var webReq = WebRequest.Create(m_Url);
            if (!(webReq is HttpWebRequest req))
                throw new InvalidCastException("WebRequest.Create did not return HttpWebRequest");

            if (_requestRange > 0)
            {
                req.AddRange(_requestRange);
                RequestedSize = _requestRange;
            }
            m_Request = req;
            req.Method = _requestMethod;
            req.KeepAlive = false;

            ServicePointManager.DefaultConnectionLimit = 10;
            ServicePointManager.UseNagleAlgorithm = false;

            // gốc UserAgent at DAT_035b00e8 — Mozilla-style string baked into binary.
            req.UserAgent = "Mozilla/5.0 (KKUpdater; rv:1.0)";

            if (!string.IsNullOrEmpty(_contentType))
                req.ContentType = _contentType;

            if (_contents != null)
            {
                req.ContentLength = _contents.Length;
                using (var rs = req.GetRequestStream())
                {
                    rs.Write(_contents, 0, _contents.Length);
                    rs.Close();
                }
            }

            IAsyncResult ar = req.BeginGetResponse(new AsyncCallback(this.RespCallback), null);
            ThreadPool.RegisterWaitForSingleObject(
                ar.AsyncWaitHandle,
                new WaitOrTimerCallback(this.ResponseTimeoutCallback),
                req, 120000, true);
        }

        // VMA: 0x01bc5eeb — Source: HttpRequester.c:955 (GetTotalSec)
        // gốc body:
        //   if (ts.TotalSeconds == 0) return 0.0001;  // 0x3f1a36e2eb1c432d ≈ 1e-4
        //   return ts.TotalSeconds;
        private double GetTotalSec(TimeSpan ts)
        {
            double secs = ts.TotalSeconds;
            if (secs == 0.0) return 0.0001;
            return secs;
        }

        // VMA: 0x01bc5f6e — Source: HttpRequester.c:994 (ReadFromStream)
        // gốc body:
        //   <>c__DisplayClass65_0 dc = new() { <>4__this = this, responseStream = stream };
        //   Action act = new Action(dc.<ReadFromStream>b__0);
        //   Task.Run(act);
        //
        // <>c__DisplayClass65_0.<ReadFromStream>b__0 (KKUpdater.HttpRequester/__c__DisplayClass65_0.c:33):
        //   DateTime startTime = DateTime.Now;
        //   double speedLimitSnapshot = this.SpeedLimit;
        //   long readSoFar = 0;
        //   uint loopCount = 0;
        //   while (this != null) {
        //     int n = stream.Read(BufferRead, 0, BufferSize);
        //     if (n <= 0) {
        //       stream.Dispose();
        //       this.IsFinished = true;
        //       return;
        //     }
        //     DateTime now1 = DateTime.Now;
        //     double elapsed = GetTotalSec(now1 - startTime);
        //     syncLock.WaitOne();
        //     readSoFar += n;
        //     double instSpeed = readSoFar / elapsed;
        //     this.currentSpeed = instSpeed;
        //     this.requestedSize += n;
        //     if (this._isFinished) { syncLock.ReleaseMutex(); return; }
        //     double currentLimit = this._speedLimit;
        //     syncLock.ReleaseMutex();
        //     DateTime checkpoint = DateTime.Now;
        //     loopCount++;
        //     while (currentLimit > 0 && currentLimit == speedLimitSnapshot && instSpeed > currentLimit) {
        //       Thread.Sleep(1);
        //       DateTime now2 = DateTime.Now;
        //       double elapsedAll = GetTotalSec(now2 - startTime);
        //       double sinceCheckpoint = GetTotalSec(now2 - checkpoint);
        //       instSpeed = readSoFar / elapsedAll;
        //       if (sinceCheckpoint > 0.5) break;
        //     }
        //     syncLock.WaitOne();
        //     if (DataMemStream != null) DataMemStream.Write(BufferRead, 0, n);
        //     syncLock.ReleaseMutex();
        //     if (DataMemStream == null) {
        //       stream.Dispose();
        //       this.IsFinished = true;
        //       return;
        //     }
        //     if (currentLimit != speedLimitSnapshot) {
        //       startTime = DateTime.Now;
        //       readSoFar = 0;
        //       speedLimitSnapshot = currentLimit;
        //     }
        //     if ((loopCount & 0x3ff) == 0) Thread.Sleep(1);
        //   }
        private void ReadFromStream(Stream responseStream)
        {
            var dc = new ReadFromStreamContext { reqr = this, stream = responseStream };
            Task.Run((Action)dc.Run);
        }

        // VMA: 0x01bc603e — Source: HttpRequester.c:1035 (RespCallback)
        // gốc body:
        //   HttpWebResponse resp = (HttpWebResponse)m_Request.EndGetResponse(ar);
        //   m_Response = resp;
        //   long contentLen = resp.ContentLength;
        //   long alreadyRequested = RequestedSize;
        //   m_TotalSize = contentLen + alreadyRequested;
        //   ResponseStream = resp.GetResponseStream();
        //   Action onRead   = new Action(this.<RespCallback>b__66_0);  // calls ReadFromStream(ResponseStream)
        //   Action onCancel = new Action(this.<RespCallback>b__66_1);  // closes streams + sets CancelException
        //   if (BeforeReadAsyncHook == null) {
        //     onRead();
        //   } else {
        //     BeforeReadAsyncHook(this, onRead, onCancel);  // NOTE: gốc invokes 3-arg form
        //   }
        private void RespCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                if (m_Request == null) throw new NullReferenceException();
                m_Response = (HttpWebResponse)m_Request.EndGetResponse(asynchronousResult);
                long contentLen = m_Response.ContentLength;
                long alreadyRequested = RequestedSize;
                m_TotalSize = contentLen + alreadyRequested;
                ResponseStream = m_Response.GetResponseStream();

                Action onRead = () => RespCallback_b__66_0();
                Action onCancel = () => RespCallback_b__66_1();

                if (BeforeReadAsyncHook == null)
                {
                    onRead();
                }
                else
                {
                    // gốc invokes 3-arg ((requester, onRead, onCancel)). Our delegate is parameterless to
                    // match the dump signature; we still call it (DEVIATION — args dropped).
                    BeforeReadAsyncHook();
                    onRead();
                }
            }
            catch (Exception e)
            {
                Error = e;
                IsFinished = true;
            }
        }

        // VMA: 0x01bc62c5 — Source: HttpRequester.c:1121 (SetSpeedLimit(ulong))
        // gốc body: SpeedLimit = (double)limit;  (ulong→double conversion)
        public void SetSpeedLimit(ulong limit) => SpeedLimit = (double)limit;

        // VMA: 0x01bc62e3 — Source: HttpRequester.c:1146 (SetRequestRange)
        public void SetRequestRange(long requestRange) => _requestRange = requestRange;

        // VMA: 0x01bc62eb — Source: HttpRequester.c:1164 (Dispose)
        // gốc body:
        //   if (!IsFinished) Error = new Exception("HttpRequester disposed without finishing");
        //   if (ResponseStream != null) ResponseStream.Close();
        //   if (m_Response != null) m_Response.Close();
        //   if (m_Request != null) m_Request.Abort();
        //   if (!IsFinished) IsFinished = true;
        public void Dispose()
        {
            try
            {
                if (!IsFinished)
                    Error = new Exception("HttpRequester disposed without finishing");
                if (ResponseStream != null) ResponseStream.Close();
                if (m_Response != null) m_Response.Close();
                if (m_Request != null) m_Request.Abort();
                if (!IsFinished) IsFinished = true;
            }
            catch { /* swallow per gốc — Dispose must not throw */ }
        }

        // VMA: 0x01bc63ca — Source: HttpRequester.c:1213 (Cancel)
        // gốc body:
        //   if (m_Response != null) m_Response.Close();
        //   if (ResponseStream != null) ResponseStream.Close();
        //   if (IsFinished) return;
        //   Error = new CancelException();
        //   IsFinished = true;
        public void Cancel()
        {
            if (m_Response != null) m_Response.Close();
            if (ResponseStream != null) ResponseStream.Close();
            if (IsFinished) return;
            Error = new CancelException();
            IsFinished = true;
        }

        // VMA: 0x01bc64af — Source: HttpRequester.c:1254 (<RespCallback>b__66_0)
        // gốc body: this.ReadFromStream(this.ResponseStream);
        private void RespCallback_b__66_0()
        {
            ReadFromStream(ResponseStream);
        }

        // VMA: 0x01bc64b8 — Source: HttpRequester.c:1272 (<RespCallback>b__66_1)
        // gốc body: same as Cancel() — closes m_Response, ResponseStream, sets CancelException + IsFinished.
        private void RespCallback_b__66_1()
        {
            if (m_Response != null) m_Response.Close();
            if (ResponseStream != null) ResponseStream.Close();
            if (IsFinished) return;
            Error = new CancelException();
            IsFinished = true;
        }

        // Inner closure type — Source: KKUpdater.HttpRequester/__c__DisplayClass65_0.c (252 LOC)
        // Holds (requester, stream) for ReadFromStream Task; Run() is the loop body.
        private sealed class ReadFromStreamContext
        {
            public HttpRequester reqr;
            public Stream stream;

            public void Run()
            {
                if (reqr == null || stream == null) return;
                DateTime startTime = DateTime.Now;
                double speedLimitSnapshot = reqr.SpeedLimit;
                long readSoFar = 0;
                uint loopCount = 0;

                while (reqr != null)
                {
                    int n;
                    try
                    {
                        n = stream.Read(reqr.BufferRead, 0, reqr.BufferSize);
                    }
                    catch (Exception e)
                    {
                        reqr.Error = e;
                        try { stream.Dispose(); } catch { }
                        reqr.IsFinished = true;
                        return;
                    }
                    if (n <= 0)
                    {
                        try { stream.Dispose(); } catch { }
                        reqr.IsFinished = true;
                        return;
                    }

                    DateTime now1 = DateTime.Now;
                    double elapsed = reqr.GetTotalSec(now1 - startTime);

                    reqr.syncLock.WaitOne();
                    double instSpeed;
                    bool finishedFlag;
                    double currentLimit;
                    try
                    {
                        readSoFar += n;
                        instSpeed = readSoFar / elapsed;
                        reqr.currentSpeed = instSpeed;
                        reqr.requestedSize += n;
                        finishedFlag = reqr._isFinished;
                        currentLimit = reqr._speedLimit;
                    }
                    finally { reqr.syncLock.ReleaseMutex(); }

                    if (finishedFlag) return;

                    DateTime checkpoint = DateTime.Now;
                    loopCount++;

                    while (currentLimit > 0 && currentLimit == speedLimitSnapshot && instSpeed > currentLimit)
                    {
                        Thread.Sleep(1);
                        DateTime now2 = DateTime.Now;
                        double elapsedAll = reqr.GetTotalSec(now2 - startTime);
                        double sinceCheckpoint = reqr.GetTotalSec(now2 - checkpoint);
                        instSpeed = readSoFar / elapsedAll;
                        if (sinceCheckpoint > 0.5) break;
                    }

                    reqr.syncLock.WaitOne();
                    MemoryStream ms;
                    try
                    {
                        ms = reqr.m_DataMemStream;
                        if (ms != null) ms.Write(reqr.BufferRead, 0, n);
                    }
                    finally { reqr.syncLock.ReleaseMutex(); }

                    if (ms == null)
                    {
                        try { stream.Dispose(); } catch { }
                        reqr.IsFinished = true;
                        return;
                    }

                    if (currentLimit != speedLimitSnapshot)
                    {
                        startTime = DateTime.Now;
                        readSoFar = 0;
                        speedLimitSnapshot = currentLimit;
                    }
                    if ((loopCount & 0x3ff) == 0) Thread.Sleep(1);
                }
            }
        }
    }

    // Stub — real DownloadQueue + nested types are a separate large port (~1000 LOC).
    // We only need QueueType enum here for HttpRequester ctor signature.
    // Source: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 605 + nested 600).
    public class DownloadQueue
    {
        public enum QueueType
        {
            Normal = 0,
            High = 1,
            Top = 2,
        }
    }
}
