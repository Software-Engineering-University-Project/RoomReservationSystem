using System;

namespace Manager
{
    public abstract class Manager<T> {

        public abstract void delete();

        public abstract T get();
    }
}
