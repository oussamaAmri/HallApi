namespace HallApi.Examples
{
    public class ExampleStatic
    {
        public void Execute()
        {
            var myInstance = new MyClass();
            var result1 = myInstance.GetNotStaticInt();
            
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
