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
           
            
            //Covariance in Arrays
            //It is risky for type safety
            //Because although we can assign a string array to an object array reference,
            //we can still attempt to separately assign different type values to the elements of object array reference via indexer
            //Which would cause a run time error. Check the following ex.
            object[] obj3 = new string[]{};
            //obj3[0] = 25; //As you can see, the compiler does not warn about this which will throw an error during runtime.
            
            
            //Covariance in Return Methods
            //Check Animal and Cat classes below
            
            
            //Covariance in Generics
            //We basically need to add out keyword to the generic parameters to utilize from Covariance.
            //This feature is merely applicable to interfaces and delegates as far as I have learned until now.
            IAnimal<object> str = new Dog<String>{ };
        }
    }
    class Animal{public virtual object getAnimal() { return null; }}
    //Although getAnimal() method is overriden, the type of the return changed into a class derived from the initial type.
    //This is also due to Coveriance.
    class Cat : Animal {public override String getAnimal() { return null; }}
    
    
    interface IAnimal<out t>{} //Remove out keyword to see the error at 41st line
    class Dog<t> : IAnimal<t> {}
    
}
