namespace WiB
{
    /*
    //*********************************************************************************************
    public class MemoryUnpacking : MemoryStorage, IUnpacking
    {
        internal MemoryUnpacking(StorageBasePool pool, int level) : base(pool, level) { }
        public MemoryUnpacking(byte[] data, int offset = 0) : base(data) { mOffset = offset; }
        //-----------------------------------------------------------------------------------------
        public void Reset() { mOffset = 0;}
        //-----------------------------------------------------------------------------------------
        //bool
        public bool UnpackingBool(int offsetBuffer) { return Memory.Unpacking<bool>(Buffer, offsetBuffer); }
        public bool UnpackingBool() { return Memory.Unpacking<bool>(Buffer, ref mOffset); }
        //-----------------------------------------------------------------------------------------
        //int
        public int UnpackingInt(int offsetBuffer) { return Memory.Unpacking<int>(Buffer, offsetBuffer); }
        public int UnpackingInt() { return Memory.Unpacking<int>(Buffer, ref mOffset); }
        //-----------------------------------------------------------------------------------------
        //float
        public float UnpackingFloat(int offsetBuffer) { return Memory.Unpacking<float>(Buffer, offsetBuffer); }
        public float UnpackingFloat() { return Memory.Unpacking<float>(Buffer, ref mOffset); }
        //-----------------------------------------------------------------------------------------
        //byte
        public byte UnpackingByte(int offsetBuffer) { return Memory.Unpacking<byte>(Buffer, offsetBuffer); }
        public byte UnpackingByte() { return Memory.Unpacking<byte>(Buffer, ref mOffset); }
        //-----------------------------------------------------------------------------------------
        //double
        public double UnpackingDouble(int offsetBuffer) { return Memory.Unpacking<double>(Buffer, offsetBuffer); }
        public double UnpackingDouble() { return Memory.Unpacking<double>(Buffer, ref mOffset); }
        //-----------------------------------------------------------------------------------------
        //short
        public short UnpackingShort(int offsetBuffer) { return Memory.Unpacking<short>(Buffer, offsetBuffer); }
        public short UnpackingShort() { return Memory.Unpacking<short>(Buffer, ref mOffset); }
        //-----------------------------------------------------------------------------------------
        //param
        public Param UnpackingParam(int offsetBuffer) { return Memory.Unpacking<Param>(Buffer, offsetBuffer); }
        public Param UnpackingParam() { return Memory.Unpacking<Param>(Buffer, ref mOffset); }
        //-----------------------------------------------------------------------------------------
        //array
        public byte[] UnpackingArray(int offsetBuffer) { return Memory.UnpackingArray(Buffer, ref offsetBuffer); }
        public byte[] UnpackingArray() { return Memory.UnpackingArray(Buffer, ref mOffset); }
        //-----------------------------------------------------------------------------------------
        //string
        public string UnpackingString(int offset) { return Memory.UnpackingString(Buffer, ref offset); }
        public string UnpackingString() { return Memory.UnpackingString(Buffer, ref mOffset); }
        //-----------------------------------------------------------------------------------------
        //GuidEx
        public GuidEx UnpackingGuidEx(int offset) { return Memory.Unpacking<GuidEx>(Buffer, ref offset); }
        public GuidEx UnpackingGuidEx() { return Memory.Unpacking<GuidEx>(Buffer, ref mOffset); }
    }
    //*********************************************************************************************
    */
}
