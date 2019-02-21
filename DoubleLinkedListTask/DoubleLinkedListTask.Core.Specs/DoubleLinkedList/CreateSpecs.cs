using FluentAssertions;
using NUnit.Framework;
using System;
using TestStack.BDDfy;

namespace DoubleLinkedListTask.Core.Specs
{
    public class CreateSpecs
    {
        private IDoubleLinkedList<object> _doubleLinkedList;

        [Test]
        public void CreateListCompletesSuccessfully()
        {
            this.Given(s => s.Nothing())
                .Then(s => s.CouldCreateList())
                .BDDfy();
        }

        [Test]
        public void CreatedListIsEmpty()
        {
            this.Given(s => s.Nothing())
                .When(s => s.CreateList())
                .Then(s => s.ShouldBeEmpty())
                .BDDfy();
        }
        
        private void Nothing()
        {
        }

        private void CreateList()
        {
            _doubleLinkedList = new DoubleLinkedList<object>();
        }

        private void CouldCreateList()
        {
            Action act = () => { _doubleLinkedList = new DoubleLinkedList<object>(); };
            act.Should().NotThrow();
        }

        private void ShouldBeEmpty()
        {
            _doubleLinkedList.First.Should().BeNull();
            _doubleLinkedList.Last.Should().BeNull();
            _doubleLinkedList.Count.Should().Be(0);
            _doubleLinkedList.Should().BeEmpty();
            _doubleLinkedList.Reverse();
        }
    }
}