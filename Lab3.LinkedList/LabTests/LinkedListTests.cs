using System;
using Xunit;
using FluentAssertions;
using AntrasLab.Methods;
using System.Collections;
using System.Linq;

namespace LabTests
{
    public class LinkedListTests
    {
        [Fact]
        public void IsEmpty_List_True()
        {
            LinkedList<Agent> list = new LinkedList<Agent>();
            list.IsEmpty().Should().BeTrue();
        }

        [Fact]
        public void IsEmpty_List_False()
        {
            LinkedList<Agent> list = new LinkedList<Agent>();
            list.Add(new Agent("DUMMY", "DUMMY", "DUMMY", "DUMMY", "DUMMY"));
            list.IsEmpty().Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void Count_How_Many_Added_To_List(int count)
        {
            LinkedList<Agent> list = new LinkedList<Agent>();
            for(int i = 0; i < count; i++)
            {
                list.Add(new Agent("DUMMY", "DUMMY", "DUMMY", "DUMMY", "DUMMY"));
            }

            list.Count().Should().Be(count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void Get_Specific_Index(int index)
        {
            LinkedList<Agent> list = new LinkedList<Agent>();

            Agent dummy = new Agent("DUMMY", "DUMMY", "DUMMY", "DUMMY", "DUMMY");
            Agent bore = new Agent("BORE", "BORE", "BORE", "BORE", "BORE");

            if (index == 0)
            {
                list.Add(dummy);
                for(int i = 1; i < 5; i++) { list.Add(bore); }
            }
            if (index == 1)
            {
                list.Add(bore);
                list.Add(dummy);
                for(int i = 2; i < 5; i++) { list.Add(bore); }
            }
            if(index == 5)
            {
                for(int i = 0; i < 5; i++) { list.Add(bore); }
                list.Add(dummy);
            }

            list.Get(index).Name.Should().Be(dummy.Name);
        }

        [Fact]
        public void Sort_List_Is_Empty()
        {
            LinkedList<Agent> list = new LinkedList<Agent>();
            LinkedList<Agent> listCopy = list;
            list.Sort();

            list.Equals(listCopy).Should().BeTrue();
        }

        [Fact]
        public void Sort_Works()
        {
            LinkedList<Agent> list = new LinkedList<Agent>();
            list.Add(new Agent("ZUMMY", "ZUMMY", "ZUMMY", "ZUMMY", "ZUMMY"));
            list.Add(new Agent("DUMMY", "DUMMY", "DUMMY", "DUMMY", "DUMMY"));
            
            list.Sort();
            list.Get(0).Should().BeLessThan(list.Get(1));
        }
        [Fact]
        public void Sort_Customer_Data_Works_AgentCode()
        {
            LinkedList<Customer> list = new LinkedList<Customer>();
            list.Add(new Customer("DUMMY", "DUMMY", "DUMMY", 1, 2, "DUMMY", 2, "ZUMMY"));
            list.Add(new Customer("DUMMY", "DUMMY", "DUMMY", 1, 2, "DUMMY", 2, "DUMMY"));

            list.Sort();
            list.Get(0).Should().BeLessThan(list.Get(1));

        }
        [Fact]
        public void Sort_Customer_Data_Works_Adress()
        {
            LinkedList<Customer> list = new LinkedList<Customer>();
            list.Add(new Customer("ZUMMY", "DUMMY", "DUMMY", 1, 2, "DUMMY", 2, "DUMMY"));
            list.Add(new Customer("DUMMY", "DUMMY", "DUMMY", 1, 2, "DUMMY", 2, "DUMMY"));

            list.Sort();
            list.Get(0).Should().BeLessThan(list.Get(1));

        }
        [Fact]
        public void Sort_Customer_Data_Works_LastName()
        {
            LinkedList<Customer> list = new LinkedList<Customer>();
            list.Add(new Customer("DUMMY", "ZUMMY", "DUMMY", 1, 2, "DUMMY", 2, "DUMMY"));
            list.Add(new Customer("DUMMY", "DUMMY", "DUMMY", 1, 2, "DUMMY", 2, "DUMMY"));

            list.Sort();
            list.Get(0).Should().BeLessThan(list.Get(1));

        }
    }
}
