// Class:  KKUpdater.MergedStream
// GUID:   6ff24c1f0ab3bf322820f68f3667c617 (preserved via .meta)
// Source: KTO_DecompiledReference/KKUpdater/MergedStream.c (13 methods, 436 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1370)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.
// Inherits System.IO.Stream — concatenates two streams as a single read-only Stream.
// Used by Md5Helper.Md5File when salt is provided (file + salt → merged → MD5).

using System;
using System.IO;

namespace KKUpdater
{
    public class MergedStream : Stream
    {
        // Fields (offsets từ dump.cs)
        private Stream s1;     // 0x28
        private Stream s2;     // 0x30

        // VMA: 0x01bc74ae — Source: MergedStream.c:15 (.ctor)
        // gốc body:
        //   System_IO_Stream___ctor(this, 0);
        //   this.s1 = first;
        //   this.s2 = second;
        public MergedStream(Stream first, Stream second)
        {
            s1 = first;
            s2 = second;
        }

        // VMA: 0x01bc7542 — Source: MergedStream.c:42 (Read)
        // gốc body:
        //   long len1 = s1.Length;
        //   long pos1 = s1.Position;
        //   int read = 0;
        //   int n1 = (int)Math.Min(count, len1 - pos1);
        //   if (n1 > 0) read = s1.Read(buffer, offset, n1);
        //   if (n1 < count) {
        //     int n2 = s2.Read(buffer, offset + n1, count - n1);
        //     read += n2;
        //   }
        //   return read;
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (s1 == null || s2 == null) throw new NullReferenceException();
            long len1 = s1.Length;
            long pos1 = s1.Position;
            int read = 0;
            int n1 = (int)Math.Min((long)count, len1 - pos1);
            if (n1 > 0) read = s1.Read(buffer, offset, n1);
            if (n1 < count)
            {
                int n2 = s2.Read(buffer, offset + n1, count - n1);
                read += n2;
            }
            return read;
        }

        // VMA: 0x01bc7650 — Source: MergedStream.c:99 (Write)
        // gốc body: throw new NotImplementedException(<DAT_035a27c0>);
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        // VMA: 0x01bc7698 — Source: MergedStream.c:125 (get_CanRead)
        // gốc body: return s1.CanRead && s2.CanRead;
        public override bool CanRead
        {
            get
            {
                if (s1 == null || s2 == null) throw new NullReferenceException();
                if (!s1.CanRead) return false;
                return s2.CanRead;
            }
        }

        // VMA: 0x01bc76df — Source: MergedStream.c:166 (get_CanSeek)
        // gốc body: return s1.CanSeek && s2.CanSeek;
        public override bool CanSeek
        {
            get
            {
                if (s1 == null || s2 == null) throw new NullReferenceException();
                if (!s1.CanSeek) return false;
                return s2.CanSeek;
            }
        }

        // VMA: 0x01bc7726 — Source: MergedStream.c:207 (get_CanWrite)
        // gốc body: return s1.CanWrite && s2.CanWrite;
        public override bool CanWrite
        {
            get
            {
                if (s1 == null || s2 == null) throw new NullReferenceException();
                if (!s1.CanWrite) return false;
                return s2.CanWrite;
            }
        }

        // VMA: 0x01bc776d — Source: MergedStream.c:248 (Flush)
        // gốc body: s1.Flush(); s2.Flush();
        public override void Flush()
        {
            if (s1 == null || s2 == null) throw new NullReferenceException();
            s1.Flush();
            s2.Flush();
        }

        // VMA: 0x01bc77ac — Source: MergedStream.c:283 (get_Length)
        // gốc body: return s1.Length + s2.Length;
        public override long Length
        {
            get
            {
                if (s1 == null || s2 == null) throw new NullReferenceException();
                return s1.Length + s2.Length;
            }
        }

        // VMA: 0x01bc77f8 / 0x01bc7844 — Source: MergedStream.c:314/345 (get/set_Position)
        // gốc body (get): return s1.Position + s2.Position;
        // gốc body (set): throw new NotImplementedException(<DAT_035840a0>);
        public override long Position
        {
            get
            {
                if (s1 == null || s2 == null) throw new NullReferenceException();
                return s1.Position + s2.Position;
            }
            set { throw new NotImplementedException(); }
        }

        // VMA: 0x01bc787d — Source: MergedStream.c:370 (Seek)
        // gốc body: throw new NotImplementedException(<DAT_03584088>);
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        // VMA: 0x01bc78b6 — Source: MergedStream.c:395 (SetLength)
        // gốc body: throw new NotImplementedException(<DAT_03584090>);
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        // VMA: 0x01bc78ef — Source: MergedStream.c:420 (System.IDisposable.Dispose)
        // gốc body: s1.Dispose(); s2.Dispose();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (s1 != null) s1.Dispose();
                if (s2 != null) s2.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
