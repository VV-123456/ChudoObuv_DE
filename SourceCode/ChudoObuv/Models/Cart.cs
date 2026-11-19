using System.Collections.Generic;

namespace ChudoObuv.Models
{
    public static class Cart
    {
        public static List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}