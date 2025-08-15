using System;

namespace Calluna.JamBasics
{
    public class SingletonException : Exception
    {
        public SingletonException(string text) : base(text)
        {
            
        }

        public static SingletonException CreateNoInstanceException(Type instanceType)
        {
            return new SingletonException(
                $"There is no singleton object of type {instanceType} in the scene.");
        }

        public static SingletonException CreateMultipleInstancesException(Type instanceType)
        {
            return new SingletonException(
                $"There are multiple singleton objects of type {instanceType} in the scene.");
        }
    }
}
