namespace HallApi.Examples
{
    public class Initializers
    {
        public void ExampleInitializers()
        {
            // 3 façons identiques d'instancier une classe
            var myCar1 = new Car();
            myCar1.Id = 1;

            var myCar2 = new Car
            {
                Id = 1
            };

            Car myCar3 = new()
            {
                Id = 1
            };
            //

            // 2 façons identiques d'instancier une liste
            var myList1 = new List<int>();
            myList1.Add(1);
            myList1.Add(2);
            myList1.Add(3);

            var myList2 = new List<int> { 1, 2, 3 };
            //

            // 3 façons identiques d'instancier un tableau
            var myArray1 = new int[3];
            myArray1[0] = 1;
            myArray1[1] = 2;
            myArray1[2] = 3;

            var myArray2 = new int[3] { 1, 2, 3 };

            var myArray3 = new[] { 1, 2, 3 };
            //

            // 2 façons identiques d'instancier un dictionnaire
            var myDic1 = new Dictionary<int, string>();
            myDic1.Add(4, "Red");   // Les clés doivent être unique
            myDic1.Add(1, "Green");
            myDic1.Add(7, "Orange");
            myDic1.Add(5, "Red");

            var myDic2 = new Dictionary<int, string>
            {
                { 4, "Red" },
                { 1, "Green" },
                { 7, "Orange" },
                { 5, "Red" }
            };
            //

            // Différences entre IEnumerable, Ilist, List et Array
            IEnumerable<int> myEnumerable = new List<int>() { 7 };
            var c1 = myEnumerable.Count();
            var e1 = myEnumerable.ElementAt(0);

            IList<int> myIList = new List<int>();
            var c2 = myIList.Count;
            myIList.Add(1);
            var e2 = myIList[0];

            List<int> myList = new List<int>();
            var c3 = myList.Count;
            myList.Add(1);
            myList.AddRange(new List<int> { 1, 2, 3 });
            var e3 = myList[0];

            int[] myArray = new int[] { 7 };
            var c4 = myArray.Length;
            var e4 = myArray[0];
            //
        }
    }

    public class Car
    {
        public int Id { get; set; }
    }
}
