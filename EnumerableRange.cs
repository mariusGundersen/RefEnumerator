using System;
using System.Collections;
using System.Collections.Generic;

namespace RefEnumerable
{
    public class EnumerableRange : IEnumerable<int>, IEnumerator<int>
    {
        private int state;
        private int current;
        public int count;
        private int from;
        private int to;
        public EnumerableRange(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => this;

        public int Current => this.current;

        object IEnumerator.Current => this.current;

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

        public void Reset()
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
        }
    }
}
