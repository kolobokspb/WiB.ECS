using System;
using System.Diagnostics;
using WiB.Ecs;
using WiB.Ecs.Filters;

namespace WiB.Esc.Test
{
    internal abstract class Program
    {
        private abstract class Example : ISystem
        {
            private readonly Stopwatch _stopWatch = new ();
            public double Time => _stopWatch.ElapsedMilliseconds / 1000.0f;

            public abstract void Start(World world);

            public void Update()
            {
                _stopWatch.Start();
                Test();
                _stopWatch.Stop();
            }

            protected abstract void Test();
        }
        
        private class ExampleInc1Exc0 : Example
        {
            private Storage<MoveX> _storageIncX;

            public override void Start(World world)
            {
                _storageIncX = world.GetStorage<MoveX>();
            }

            protected override void Test()
            {
                foreach (var i in new Inc1Exc0(_storageIncX))
                {
                    ref readonly var x = ref _storageIncX.GetComponent(i);
                    
                    //Console.WriteLine($"ExampleInc1Exc0 {x.X}");
                }    
            }
        }

        private class ExampleInc2Exc0 : Example
        {
            private Storage<MoveX> _storageIncX;
            private Storage<MoveY> _storageIncY;

            public override void Start(World world)
            {
                _storageIncX = world.GetStorage<MoveX>();
                _storageIncY = world.GetStorage<MoveY>();
            }

            protected override void Test()
            {
                foreach (var i in new Inc2Exc0(_storageIncX, _storageIncY))
                {
                    ref readonly var x = ref _storageIncX.GetComponent(i);
                    ref readonly var y = ref _storageIncY.GetComponent(i);
                    
                    //Console.WriteLine($"ExampleInc2Exc0 {x.X} {y.Y}");
                }
            }
        }

        private class ExampleInc3Exc0 : Example
        {
            private Storage<MoveX> _storageIncX;
            private Storage<MoveY> _storageIncY;
            private Storage<MoveZ> _storageIncZ;
            
            public override void Start(World world)
            {
                _storageIncX = world.GetStorage<MoveX>();
                _storageIncY = world.GetStorage<MoveY>();
                _storageIncZ = world.GetStorage<MoveZ>();
            }

            protected override void Test()
            {
                foreach (var i in new Inc3Exc0(_storageIncX, _storageIncY, _storageIncZ))
                {
                    ref readonly var x = ref _storageIncX.GetComponent(i);
                    ref readonly var y = ref _storageIncY.GetComponent(i);
                    ref readonly var z = ref _storageIncZ.GetComponent(i);
                    
                    //Console.WriteLine($"ExampleInc3Exc0 {x.X} {y.Y} {z.Z}");
                }
            }
        }

        private class ExampleInc1Exc1 : Example
        {
            private Storage<MoveX> _storageIncX;
            private Storage<MoveY> _storageExcY;

            public override void Start(World world)
            {
                _storageIncX = world.GetStorage<MoveX>();
                _storageExcY = world.GetStorage<MoveY>();
            }

            protected override void Test()
            {
                foreach (var i in new Inc1Exc1(_storageIncX, _storageExcY))
                {
                    ref readonly var x = ref _storageIncX.GetComponent(i);
                    
                    //Console.WriteLine($"ExampleInc1Exc1 {x.X}");
                }
            }
        }

        private readonly struct MoveX
        {
            public MoveX(int x)
            {
                X = x;
            }
            public readonly int X;
            
        }

        private readonly struct MoveY
        {
            public MoveY(int x)
            {
                X = x;
            }
            public readonly int X;
        }

        private readonly struct MoveZ
        {
            public MoveZ(int x)
            {
                X = x;
            }
            public readonly int X;
        }

        private static void Main()
        {
            Console.WriteLine($"Performance test...");

            var world = new World();

            var poolMoveX = world.BindComponent<MoveX>();
            var poolMoveY = world.BindComponent<MoveY>();
            var poolMoveZ = world.BindComponent<MoveZ>();

            var inc1Exc0 = new ExampleInc1Exc0();
            world.AddSystem(inc1Exc0);

            var inc2Exc0 = new ExampleInc2Exc0();
            world.AddSystem(inc2Exc0);

            var inc3Exc0 = new ExampleInc3Exc0();
            world.AddSystem(inc3Exc0);

            var inc1Exc1 = new ExampleInc1Exc1();
            world.AddSystem(inc1Exc1);
            
            //inc1Exc0.
            
            world.Start();

            const long numberOfEntities = 1_000;
            //const long numberOfEntities = 100;

            for (var i = 0; i != numberOfEntities; i++)
            {
                var entity1 = world.CreateEntity();

                //filling 100%
                var x = new MoveX(i);
                poolMoveX.SetComponent(entity1, ref x);

                //filling 50%
                var y = new MoveY(i);
                if (i % 2 == 0)
                    poolMoveY.SetComponent(entity1, ref y);

                //filling 33%
                var z = new MoveZ(i);
                if (i % 3 == 0)
                    poolMoveZ.SetComponent(entity1, ref z);
            }

            const long numberOfUpdates = 100_000;
            //const long numberOfUpdates = 1;

            for (var i = 0; i != numberOfUpdates; i++)
                world.Update();

            const long numberOfCalls = numberOfEntities * numberOfUpdates;

            //const long calls = 1_000_000;
            

            Console.WriteLine($"-------------------------------------------------------------------------------");
            Console.WriteLine($"Average result 10^6 calls:");
            Console.WriteLine();
            Console.WriteLine($"where filling inc0-> 100%");
            Console.WriteLine($"where filling inc1-> 50%");
            Console.WriteLine($"where filling inc3-> 33%");
            Console.WriteLine($"where filling exc0-> 50%");
            Console.WriteLine();
            Console.WriteLine("filters:");
            Console.WriteLine($"a) filter include:1 exclude:0");
            Console.WriteLine($"complexity O(inc0) ------------------> (100%): {numberOfUpdates * inc1Exc0.Time / numberOfCalls} s");
            Console.WriteLine($"b) filter include:2 exclude:0");
            Console.WriteLine($"complexity O(min(inc0, inc1)) -------> (50%) : {numberOfUpdates * inc2Exc0.Time / numberOfCalls} s");
            Console.WriteLine($"c) filter include:3 exclude:0");
            Console.WriteLine($"complexity O(min(inc0, inc1, inc2)) -> (33%) : {numberOfUpdates * inc3Exc0.Time / numberOfCalls} s");
            Console.WriteLine($"d) filter include:1 exclude:1");
            Console.WriteLine($"complexity O(inc0) ------------------> (100%): {numberOfUpdates * inc1Exc1.Time / numberOfCalls} s");
            Console.WriteLine($"-------------------------------------------------------------------------------");

            Console.ReadKey();
        }
    }
}