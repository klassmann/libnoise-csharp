using System;
using System.Collections;
using System.Collections.Generic;

namespace noise.module
{
    public abstract class Module
    {

        protected Module[] _sourceModules;

        public Module(int count)
        {
            _sourceModules = new Module[count];
        }

        public Module GetSourceModule(int index)
        {
            if (index > _sourceModules.Length)
                throw new Exception(string.Format("{0} is greater than the module count.", index));
            return _sourceModules[index];
        }

        public void SetSourceModule(int index, Module m)
        {
            if (index > GetSourceModuleCount() || index < 0)
                throw new Exception("Invalid index for Source Module.");
            _sourceModules[index] = m;
        }

        public abstract int GetSourceModuleCount();

        public abstract double GetValue(double x, double y, double z);
    }
}