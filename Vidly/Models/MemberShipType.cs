using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        public string NameType { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
        public static byte Unknown { get; internal set; }
        public static object PayAsYouGo { get; internal set; }
    }
}