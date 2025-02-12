namespace CPPPPAdvancedProgramming9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Covariance & Contravariance
            //These two definitions are for the implicit conversion in array, deligate, return, and generic types.
            //E.g.
            object obj1 = new String("Efe") { };
            //We know that here, all the classes stem from object class and we can assign an instance of a class to a reference point of another class the instance's class inherits thanks to polymorphism.
            //So we got no compiler errors.
            object[] objs1 = new String[] { };
            //What about here? We know that arrays are different thingies than actual classes
            //so have these both object[] and String[] got a inheritanceship? -Nope
            //This line did not cause an error anyway thanks to Covariance (the implicit conversion behaviour we can set to types listed in the very firs sentence).

            //To be more specific in definitions of both patterns:
            //Covariance is the ability of referencing specific types with general types in  arrays, deligates, return types, and generics.
            /*Like*/
            IEnumerable<object> obj2 = new List<String>();
            //Contravariance is the opposite of Covariance.
            //For Contravariance's Example, I will finish the deligates tutorial and will be back here as this definition is known with deligates.
        }
    }
}
