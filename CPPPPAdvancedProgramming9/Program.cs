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
            //Check the Delegates part for the contravariance illustration.
            
            
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
            
            
            //Covariance in Delegates
            //It requires out keyword in the generic parameter in the delegate declaration as the generics do.
            Sinif1 Sinif1Obj = new Sinif1();
            Sinif2 Sinif2Obj = new Sinif2();
            ExpHandler<Sinif1> ExpDelegate1 = Sinif1Obj.ExpMethod<Sinif1>;
            ExpHandler<Sinif2> ExpDelegate2 = Sinif2Obj.ExpMethod<Sinif2>;
            ExpDelegate1 = ExpDelegate2;
            
            //Contravariance in Delegates (Generics)
            ExpHandler1<Sinif1> ExpDelegate11 = Sinif1Obj.ExpMethod<Sinif1>;
            ExpHandler1<Sinif2> ExpDelegate21 = Sinif2Obj.ExpMethod<Sinif2>;
            ExpDelegate21 = ExpDelegate11; 
            //Although Sinif2 is the derived class, the delegate with the derived class argument
            //can reference another one's instance with the base class generic argument.
        }
    }
    class Animal{public virtual object getAnimal() { return null; }}
    //Although getAnimal() method is overriden, the type of the return changed into a class derived from the initial type.
    //This is also due to Coveriance.
    class Cat : Animal {public override String getAnimal() { return null; }}
    
    
    interface IAnimal<out t>{} //Remove out keyword to see the error at 41st line
    class Dog<t> : IAnimal<t> {}
    
    
    //Delegates 
    class Sinif1 { public virtual void ExpMethod<t1>() { } }

    class Sinif2 : Sinif1 { public override void ExpMethod<t1>() {} }
    public delegate void ExpHandler<out t1>();
    public delegate void ExpHandler1<in t1>(); //We use in keyword for the contravariance behaviour
}