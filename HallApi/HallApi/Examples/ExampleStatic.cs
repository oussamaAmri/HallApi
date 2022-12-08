namespace HallApi.Examples
{
    public class ExampleStatic
    {
        public void Execute()
        {
            var myClass = new MyClass();

            var result1 = myClass.GetNotStaticInt();
            var result2 = MyClass.GetStaticInt();
        }
    }

    public class MyClass
    {
        public int GetNotStaticInt()
        {
            return 1;
        }

        public static int GetStaticInt()
        {
            return 1;
        }
    }
}
