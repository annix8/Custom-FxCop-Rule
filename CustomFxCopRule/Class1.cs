using System;
using System.Security.Cryptography;

namespace CustomFxCopRule
{
    public class Class1
    {
        // MD5 is the class which is marked as not recommended in the FxCop rule so the report should generate several warnings for this class
        private readonly MD5 _md5 = new MD5CryptoServiceProvider();
        public MD5 SomeProp { get; set; }

        public Class1(MD5 md5)
        {

        }

        public void DoSomething()
        {
            var a = new MD5CryptoServiceProvider();
            var rand = new Random();
        }
    }
}
