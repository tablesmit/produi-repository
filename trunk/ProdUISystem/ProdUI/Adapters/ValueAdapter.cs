﻿// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
namespace ProdUI.Adapters
{
    public interface ValueAdapter
    {
        string Value { get; set; }
        bool IsReadOnly { get; }
    }
}