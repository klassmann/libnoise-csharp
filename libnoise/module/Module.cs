using System;
using System.Collections;
using System.Collections.Generic;

namespace noise.module {
    public abstract class Module {

        protected List<Module> _sourceModules;

        // public Module(int count) {

        // }


        // public Module GetSourceModule(int index) {
        //     return null;
        // }

        public abstract int GetSourceModuleCount();

        public abstract double GetValue(double x, double y, double z);
    }
}