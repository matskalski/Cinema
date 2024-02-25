using Cinema.Models;

//var places = GetPlacesPairs();
ConsoleKeyInfo pressedKey;

IEnumerable<BasePlace> places = GetPlacesPairs();

int maxRowOffset = places.Max(pp => pp.RowOffset);
int maxColumnOffser = places.Max(pp => pp.ColumnOffset);

bool specialPlacesReserved = false;

while (true)
{
    Console.WriteLine("Dostępne pary lub miejsca podwójne: " + places.Count().ToString());
    Console.WriteLine("Czy chcesz zarezerwować kolejne dwa miejsca lub miejsce podwójne?");
    Console.WriteLine("Tak: Y");
    Console.WriteLine("Nie: N");
    if (!specialPlacesReserved)
    {
        Console.WriteLine("Zarezerwuj miejsca dla niepełnosprawnych: S");
    }


    pressedKey = Console.ReadKey();
    Console.WriteLine();
    Console.WriteLine();

    if (pressedKey.KeyChar.ToString().ToUpper() == "N")
    {
        Console.WriteLine("Zakończono");
        break;
    }
    else if (pressedKey.KeyChar.ToString().ToUpper() == "Y")
    {
        places = places.Where(ap => ap.Free);

        if (!places.Any())
        {
            Console.WriteLine("Brak dostępnych par");
            break;
        }

        var result = BookPlaces();
        if (result.GetType() == typeof(PlacePair))
        {
            var placePair = result as PlacePair;
            Console.WriteLine($"Zarezerwowano miejsca: Rząd {result.Row}, miejsca: {placePair.Numbers.Item1}, {placePair.Numbers.Item2}");
        }
        else
        {
            var doublePlace = result as DoublePlace;
            Console.WriteLine($"Zarezerwowano miejsce podówjne: Rząd {result.Row}, miejsce: {doublePlace.Number}");
        }
    }
    else if (pressedKey.KeyChar.ToString().ToUpper() == "S" && !specialPlacesReserved)
    {
        specialPlacesReserved = true;
        Console.WriteLine($"Zarezerwowano miejsca: Rząd 1, miejsca: 1, 2");
    }
    else
    {
        Console.WriteLine("Niepoprawna instrukcja");
    }

    Console.WriteLine("--------------------------------------------");
    Console.WriteLine();
}

BasePlace BookPlaces()
{
    BasePlace place = null;
    for (int rowOffset = 0; rowOffset <= maxRowOffset; rowOffset++)
    {
        for (int columnOffset = 0; columnOffset <= maxColumnOffser; columnOffset++)
        {
            place = places.FirstOrDefault(p => p.RowOffset == rowOffset && p.ColumnOffset == columnOffset);
            if (place != null)
            {
                place.MarkAsOccupated();
                return place;
            }
        }
    }

    return place;
}

#region data init
List<BasePlace> GetPlacesPairs()
{
    return new List<BasePlace>()
    {
        //rząd1
        new PlacePair(1, (3, 4), 0),
        new PlacePair(1, (5, 6), 1),
        new PlacePair(1, (7, 8), 2),
        new PlacePair(1, (9, 10), 3),
        new PlacePair(1, (11, 12), 4), 
        
        //rząd2
        new PlacePair(2, (2, 3), 1),
        new PlacePair(2, (4, 5), 0),
        new PlacePair(2, (6, 7), 1),
        new PlacePair(2, (8, 9), 2),
        new PlacePair(2, (10, 11), 3),
        new PlacePair(2, (12, 13), 4),
        
        //rząd3
        new PlacePair(3, (2, 3), 1),
        new PlacePair(3, (4, 5), 0),
        new PlacePair(3, (6, 7), 1),
        new PlacePair(3, (8, 9), 2),
        new PlacePair(3, (10, 11), 3),
        new PlacePair(3, (12, 13), 4),
        
        //rząd4
        new PlacePair(4, (2, 3), 1),
        new PlacePair(4, (4, 5), 0),
        new PlacePair(4, (6, 7), 1),
        new PlacePair(4, (8, 9), 2),
        new PlacePair(4, (10, 11), 3),
        new PlacePair(4, (12, 13), 4),
        
        //rząd5
        new PlacePair(5, (2, 3), 1),
        new PlacePair(5, (4, 5), 0),
        new PlacePair(5, (6, 7), 1),
        new PlacePair(5, (8, 9), 2),
        new PlacePair(5, (10, 11), 3),
        new PlacePair(5, (12, 13), 4),

        //rząd6
        new PlacePair(6, (2,3), 2),
        new PlacePair(6, (4,5), 1),
        new PlacePair(6, (6,7), 0),
        new PlacePair(6, (8,9), 1),
        new PlacePair(6, (10,11), 2),
        new PlacePair(6, (12,13), 3),
        new PlacePair(6, (14,15), 4), 
        
        //rząd7
        new PlacePair(7, (2,3), 2),
        new PlacePair(7, (4,5), 1),
        new PlacePair(7, (6,7), 0),
        new PlacePair(7, (8,9), 1),
        new PlacePair(7, (10,11), 2),
        new PlacePair(7, (12,13), 3),
        new PlacePair(7, (14,15), 4),
        
        
        //rząd8
        new PlacePair(8, (2,3), 2),
        new PlacePair(8, (4,5), 1),
        new PlacePair(8, (6,7), 0),
        new PlacePair(8, (8,9), 1),
        new PlacePair(8, (10,11), 2),
        new PlacePair(8, (12,13), 3),
        new PlacePair(8, (14,15), 4),

        //rząd9
        new DoublePlace(9, 2, 2),
        new DoublePlace(9, 4, 1),
        new DoublePlace(9, 5, 0),
        new DoublePlace(9, 6, 1),
        new DoublePlace(9, 7, 2),
        new DoublePlace(9, 8, 3),
        new DoublePlace(9, 9, 4),
        
        //rząd10
        new DoublePlace(10, 2, 2),
        new DoublePlace(10, 4, 1),
        new DoublePlace(10, 5, 0),
        new DoublePlace(10, 6, 1),
        new DoublePlace(10, 7, 2),
        new DoublePlace(10, 8, 3),
        new DoublePlace(10, 9, 4),

        //rząd11
        new DoublePlace(11, 1, 4),
        new DoublePlace(11, 2, 3),
        new DoublePlace(11, 3, 2),
        new DoublePlace(11, 4, 1),
        new DoublePlace(11, 5, 0),
        new DoublePlace(11, 6, 1),
        new DoublePlace(11, 7, 2),
        new DoublePlace(11, 8, 3),
        new DoublePlace(11, 9, 4)
    };
}
#endregion