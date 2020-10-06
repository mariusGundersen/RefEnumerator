namespace RefEnumerable
{
    public class NonRefRange : IRefEnumerable<int>, IRefEnumerator<int>
    {
        private int state;
        private int current;
        public int count;
        private int from;
        private int to;
        public NonRefRange(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public IRefEnumerator<int> GetEnumerator() => this;

        public int Current => this.current;

        public bool MoveNext()
        {
            switch (this.state)
            {
                case 0:
                    this.state = -1;
                    this.count = this.from;
                    if (this.count < this.to)
                    {
                        this.current = this.count;
                        this.state = 1;
                        return true;
                    }
                    break;

                case 1:
                    this.state = -1;
                    this.count++;
                    if (this.count < this.to)
                    {
                        this.current = this.count;
                        this.state = 1;
                        return true;
                    }
                    break;
            }
            return false;
        }
    }
}
