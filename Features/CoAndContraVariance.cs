using System;

namespace Features
{
    //covariance and contravariance enable implicit reference conversion for array types, delegate types, and generic type arguments. 
    //Covariance preserves assignment compatibility and contravariance reverses it.
    class CoAndContraVariance
    {
        public CoAndContraVariance()
        {
            // Covariance. A delegate specifies a return type as object,  
            // but you can assign a method that returns a string.  
            Func<object> del = GetString;

            // Contravariance. A delegate specifies a parameter type as string,  
            // but you can assign a method that takes an object.  
            Action<string> del2 = SetObject;

            object st = del.Invoke();
            del2.Invoke("shd");
        }

        object GetObject() { return null; }
        void SetObject(object obj) { }

        string GetString() { return ""; }
        void SetString(string str) { }
    }


}
