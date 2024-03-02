namespace FunctionProgrammingIntro.Builder
{
    public class Computer
    {
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string GPU { get; set; } // Optional component

        public Computer(string cpu, string ram, string gpu = null)
        {
            CPU = cpu;
            RAM = ram;
            GPU = gpu;
        }
        public override string ToString()
        {
            return $"CPU: {CPU}, RAM: {RAM}, GPU: {(GPU == null ? "Not included" : GPU)}";
        }
    }

    public interface IComputerBuilder
    {
        IComputerBuilder WithCPU(string cpu);
        IComputerBuilder WithRAM(string ram);
        IComputerBuilder WithGPU(string gpu); // Optional method
        Computer Build();
    }
    public class ComputerBuilder : IComputerBuilder
    {
        private string cpu;
        private string ram;
        private string gpu;

        public IComputerBuilder WithCPU(string cpu)
        {
            this.cpu = cpu;
            return this;
        }

        public IComputerBuilder WithRAM(string ram)
        {
            this.ram = ram;
            return this;
        }

        public IComputerBuilder WithGPU(string gpu)
        {
            this.gpu = gpu;
            return this;
        }

        public Computer Build()
        {
            return new Computer(cpu, ram, gpu);
        }

    }
}
