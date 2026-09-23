using Microsoft.Extensions.Logging;
using WhiteDwarf.Utilities.AbstractClasses;
using WhiteDwarf.Utilities.Interfaces;

namespace WhiteDwarf36.Sector.Listings;

public sealed class SectorListing : ConsoleRendererBase<SectorListing>
{
    private Random _random = null!;

    public SectorListing(
        ILogger<SectorListing> logger,
        IRetroDisplay display)
        : base(logger, display)
    {
        _listingData = new ListingData
        {
            Article = "Sector and Starburst",
            Author = "Marcus L. Rowland",
            Date = "December 1982",
            Issue = "WD36",
            Language = "BASIC",
            Machine = "ZX81",
            Notes = "While this is reproduced in C#,\nI have tried to stick as\nfaithfully as I can to the\noriginal flow and architecture.",
            Pages = "19-19",
            Programme = "Sector",
            Purpose = "Traveller sector generation"
        };
    }

    public override async Task RunListingCode()
    {
        _display.Clear();

        // 2000
        // SLOW

        // 2040 - 2080
        // Animated SECTOR title.
        //
        // The original does this:
        //
        // FOR N=1 TO 20
        // PRINT AT N,N; "S E C T O R"
        // PRINT AT 20-N,N;"SECTOR"
        // NEXT N

        for (var n = 1; n <= 20; n++)
        {
            _display.WriteAt(n, n, "S E C T O R");
            _display.WriteAt(n, 20 - n, "SECTOR");

            _display.Pause(200);
        }

        _display.Pause(2000);

        // 2090
        _display.Clear();

        // 2100
        _display.WriteAt(10, 5, "SECTOR");

        // 2110
        _display.WriteAt(8, 6, "BY M.L. ROWLAND");

        // 2140
        _display.WriteAt(
            0,
            10,
            "A PROGRAMME WHICH GENERATES\nSTAR CHARTS AND PLANET\n" +
            "SPECIFICATIONS BY RULES\nEXPLAINED IN TRAVELLER BOOK 3.");

        // 2145
        _display.WriteAt(
            0,
            21,
            "WHAT % OF HEXES HOLD SYSTEMS?");

        var h = ReadPercentage();

        // 2165
        _display.Clear();

        // 2170
        // RAND
        _random = new Random();

        // 2180
        var l = 7;

        // 2200
        var p = 0;

        // 2210
        for (var n = 1; n <= 4; n++)
        {
            // 2220
            var c = 0;

            // 2230
            for (var y = 1; y <= 10; y++)
            {
                // 2240
                var z = Random100();

                // 2250
                _display.WriteAt(l, c, "< >");

                // 2260
                if (z <= h)
                {
                    _display.WriteAt(l, c, "<*>");
                }

                // 2270
                if (z <= h)
                {
                    p++;
                }

                // 2280
                c++;
            }

            // 2320
            l += 4;
        }

        // 2340
        l = 10;

        // 2350
        for (var n = 1; n <= 4; n++)
        {
            // 2360
            var c = 1;

            // 2370
            for (var y = 1; y <= 9; y++)
            {
                // 2380
                var z = Random100();

                // 2390
                if (z <= h)
                {
                    _display.WriteAt(l, c, "*");
                }

                // 2400
                if (z <= h)
                {
                    p++;
                }

                // 2410
                c++;
            }

            // 2450
            l += 4;
        }

        // 2470
        _display.WriteAt(0, 20, $"{p} SYSTEMS");

        // 2480
        // PAUSE 4E4
        _display.Pause(8000);

        // 2482
        if (p == 42)
        {
            DontPanic();
        }

        // 2485
        if (p == 0)
        {
            TryAgain();
            return;
        }

        // 2490
        _display.Clear();

        // 2500
        GenerateSector(p);

        await Task.CompletedTask;
    }

    private int ReadPercentage()
    {
        while (true)
        {
            Console.Write(" ");

            var input = Console.ReadLine();

            if (int.TryParse(input, out var h) &&
                h >= 1 &&
                h <= 100)
            {
                return h;
            }

            _display.Clear();

            _display.WriteAt(
                0,
                21,
                "WHAT % OF HEXES HOLD SYSTEMS?");
        }
    }

    private void GenerateSector(int p)
    {
        // 5 FAST

        // 10 LET W=1
        var w = 1;

        // 15 FOR N=1 TO P
        for (var n = 1; n <= p; n++)
        {
            // 20 PRINT AT W,0;N
            _display.WriteAt(0, w, n.ToString());

            // 25 LET X=0
            var x = 0;

            // 30
            x = RollD6() + RollD6() + 2;

            // 35
            var a = 0;

            // 40
            a = RollD6() + RollD6();

            // 50
            var b =
                a +
                RollD6() +
                RollD6() -
                5;

            // 55
            if (a == 0)
            {
                b = 0;
            }

            // 60
            if (b <= 0)
            {
                b = 0;
            }

            // 70
            var c =
                a +
                RollD6() +
                RollD6() -
                5;

            // 80
            if (b < 1 || b > 9)
            {
                c -= 4;
            }

            // 90
            if (c <= 0)
            {
                c = 0;
            }

            // 100
            if (c >= 10)
            {
                c = 10;
            }

            // 110
            var d = RollD6() + RollD6();

            // 120
            var e =
                d +
                RollD6() +
                RollD6() -
                5;

            // 130
            if (e <= 0)
            {
                e = 0;
            }

            // 140
            if (e >= 13)
            {
                e = 13;
            }

            // 160
            var f = RollD6() + 1;

            // 170
            if (x == 12)
            {
                f -= 4;
            }

            // 180
            if (x >= 7 && x <= 8)
            {
                f += 2;
            }

            // 190
            if (x >= 5 && x <= 6)
            {
                f += 4;
            }

            // 195
            if (x >= 4)
            {
                f += 6;
            }

            // 200
            if (a >= 2 && a <= 4)
            {
                f += 1;
            }

            // 205
            if (a <= 1)
            {
                f += 2;
            }

            // 210
            if (b <= 3 || b >= 10)
            {
                f += 1;
            }

            // 220
            if (c == 9)
            {
                f += 1;
            }

            // 230
            if (c == 10)
            {
                f += 2;
            }

            // 240
            if (d >= 1 && d <= 5)
            {
                f += 1;
            }

            // 245
            if (d == 9)
            {
                f += 2;
            }

            // 250
            if (d == 10)
            {
                f += 4;
            }

            // 260
            if (e == 0 || e == 5)
            {
                f += 1;
            }

            // 265
            if (e == 13)
            {
                f -= 2;
            }

            // 270
            if (f <= 0)
            {
                f = 0;
            }

            // 275-300
            GenerateStarport(x, a, b, c, w);

            // 310-380
            PrintWorldValues(a, b, c, d, e, f, w);

            // 390
            var l = 0;

            // 400
            l =
                e +
                RollD6() +
                RollD6() -
                5;

            // 410
            if (l <= 0)
            {
                l = 0;
            }

            // 420
            if (l >= 9)
            {
                l = 9;
            }

            // 430
            _display.WriteAt(17, w, ToZx81Character(l));

            // 450
            var g = 0;

            // 455
            g = Random10();

            // 460
            if (g <= 5)
            {
                _display.WriteAt(31, w, "G");
            }

            // 555-570
            if (w == 20)
            {
                // PAUSE 4E4
                _display.Pause(8000);
                _display.Clear();
                w = 0;
            }

            w++;
        }

        // 580
        // PAUSE 4E4
        _display.Pause(8000);

        // 585
        _display.Clear();

        // 590
        // GOTO 2000
    }

    private void GenerateStarport(
        int x,
        int a,
        int b,
        int c,
        int w)
    {
        // 275
        if (x <= 4)
        {
            GenerateA(w);
        }

        // 280
        if (x >= 5 && x <= 6)
        {
            GenerateB(b, w);
        }

        // 285
        if (x >= 7 && c <= 8)
        {
            GenerateO(w);
        }

        // 290
        if (x == 9)
        {
            GenerateC(w);
        }

        // 295
        if (x >= 10 && x <= 11)
        {
            _display.WriteAt(10, w, "E");
        }

        // 300
        if (x == 12)
        {
            _display.WriteAt(10, w, "X");
        }
    }

    // 700
    private void GenerateA(int w)
    {
        _display.WriteAt(10, w, "A");

        var i = Roll2D6();

        // 720
        if (i >= 8 && i <= 9)
        {
            // 910
            _display.WriteAt(21, w, "N");
        }

        // 730
        if (i >= 10)
        {
            // 930
            _display.WriteAt(21, w, "S");
        }
    }

    // 750
    private void GenerateB(int b, int w)
    {
        _display.WriteAt(10, w, "B");

        var i = Roll2D6();

        // 770
        if (i == b)
        {
            _display.WriteAt(21, w, "N");
        }

        // 780
        if (i > b)
        {
            _display.WriteAt(21, w, "S");
        }
    }

    // 800
    private void GenerateO(int w)
    {
        _display.WriteAt(10, w, "0");

        var i = Roll2D6();

        // 820
        if (i >= 7)
        {
            _display.WriteAt(21, w, "S");
        }
    }

    // 840
    private void GenerateC(int w)
    {
        _display.WriteAt(10, w, "C");

        var i = Roll2D6();

        // 860
        if (i > 7)
        {
            _display.WriteAt(21, w, "S");
        }
    }

    // 880
    private int Roll2D6()
    {
        return RollD6() + RollD6() + 2;
    }

    private int RollD6()
    {
        // ZX81:
        // INT(RND*6)
        //
        // produces 0..5, hence +1 gives a conventional 1..6 roll.
        return _random.Next(0, 6);
    }

    private int Random10()
    {
        // INT(RND*10)
        return _random.Next(0, 10);
    }

    private int Random100()
    {
        // INT(RND*100)+1
        return _random.Next(1, 101);
    }

    private void PrintWorldValues(
        int a,
        int b,
        int c,
        int d,
        int e,
        int f,
        int w)
    {
        _display.WriteAt(12, w, ToZx81Character(a));
        _display.WriteAt(13, w, ToZx81Character(b));
        _display.WriteAt(14, w, ToZx81Character(c));
        _display.WriteAt(15, w, ToZx81Character(d));
        _display.WriteAt(16, w, ToZx81Character(e));
        _display.WriteAt(19, w, ToZx81Character(f));
    }

    private static char ToZx81Character(int value)
    {
        /*
         * The original uses:
         *
         * CHR$(value + 28)
         *
         * These are ZX81 character-set codes rather than ASCII.
         *
         * For now this is deliberately only an approximation.
         * We should implement the actual ZX81 character mapping
         * separately rather than hiding that interpretation here.
         */
        return value switch
        {
            0 => '0',
            1 => '1',
            2 => '2',
            3 => '3',
            4 => '4',
            5 => '5',
            6 => '6',
            7 => '7',
            8 => '8',
            9 => '9',
            10 => 'A',
            11 => 'B',
            12 => 'C',
            13 => 'D',
            _ => '?'
        };
    }

    private void TryAgain()
    {
        _display.Clear();

        _display.WriteAt(10, 10, "TRY AGAIN");

        // PAUSE 30
        _display.Pause(8000);

        _display.Clear();

        /*
         * Original line 2550:
         *
         *     GOTO 1000
         *
         * There is no line 1000 in the published Sector listing.
         *
         * Deliberately not reproduced as an actual jump here because
         * doing so would simply terminate/fail in the C# implementation.
         */
    }

    private void DontPanic()
    {
        _display.Clear();

        _display.WriteAt(10, 10, "DONT PANIC");

        _display.Clear();
    }
}