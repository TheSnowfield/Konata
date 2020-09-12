﻿using System.Numerics;

namespace ECDHAlgorithm
{
    using bint = BigInteger;

    internal struct EllipticCurve
    {
        public static readonly EllipticCurve SecP192k1 = new EllipticCurve(
            new bint(new byte[] {
                0x37, 0xEE, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF,
                0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0 }),
            0,
            3,
            new bint(new byte[] {
                0x7D, 0x6C, 0xE0, 0xEA, 0xB1, 0xD1, 0xA5, 0x1D,
                0x34, 0xF4, 0xB7, 0x80, 0x02, 0x7D, 0xB0, 0x26,
                0xAE, 0xE9, 0x57, 0xC0, 0x0E, 0xF1, 0x4F, 0xDB, 0 }),
            new bint(new byte[] {
                0x9D, 0x2F, 0x5E, 0xD9, 0x88, 0xAA, 0x82, 0x40,
                0x34, 0x86, 0xBE, 0x15, 0xD0, 0x63, 0x41, 0x84,
                0xA7, 0x28, 0x56, 0x9C, 0x6D, 0x2F, 0x2F, 0x9B, 0 }),
            new bint(new byte[] {
                0x8D, 0xFD, 0xDE, 0x74, 0x6A, 0x46, 0x69, 0x0F,
                0x17, 0xFC, 0xF2, 0x26, 0xFE, 0xFF, 0xFF, 0xFF,
                0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0 }),
            1,
            24
            );

        public bint P { get; }

        public bint A { get; }

        public bint B { get; }

        public Point G { get; }

        public bint N { get; }

        public bint H { get; }

        public int Size { get; }

        public bool CheckOn(Point point) => (point.Y * point.Y - point.X * point.X * point.X - A * point.X - B) % P == 0;

        private EllipticCurve(bint p, bint a, bint b, bint gx, bint gy, bint n, bint h, int size)
        {
            P = p;
            A = a;
            B = b;
            G = new Point(gx, gy);
            N = n;
            H = h;
            Size = size;
        }
    }
}