using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using TestStack.BDDfy;

namespace DoubleLinkedListTask.Core.Specs.DoubleLinkedList
{
    public class ReverseSpecs
    {
        private IDoubleLinkedList<object> _doubleLinkedList;
        private object _firstElement;
        private object _secondElement;
        private object _thirdElement;

        [Test]
        public void CouldIterateOnEmptyList()
        {
            this.Given(s => s.EmptyListAccessAplication())
                .Then(s => s.CouldReverse())
                .BDDfy();
        }

        [Test]
        public void CouldIterateOnListWithOneElement()
        {
            this.Given(s => s.ListWithOneElementAccessAplication())
                .Then(s => s.CouldReverse())
                .BDDfy();
        }

        [Test]
        public void CouldIterateOnListWithTwoElements()
        {
            this.Given(s => s.ListWithTwoElementsAccessAplication())
                .Then(s => s.CouldReverse())
                .BDDfy();
        }

        [Test]
        public void CouldIterateOnListWithThreeElements()
        {
            this.Given(s => s.ListWithThreeElementsAccessAplication())
                .Then(s => s.CouldReverse())
                .BDDfy();
        }

        [Test]
        public void IterationShouldBeCorrectOnReversedEmptyList()
        {
            this.Given(s => s.EmptyListAccessAplication())
                .When(s => s.Reverse())
                .Then(s => s.ShouldBeSequenceOf())
                .BDDfy();
        }

        [Test]
        public void IterationShouldBeCorrectOnReversedListWithOneElement()
        {
            this.Given(s => s.ListWithOneElementAccessAplication())
                .When(s => s.Reverse())
                .Then(s => s.ShouldBeSequenceOf(_firstElement))
                .BDDfy();
        }

        [Test]
        public void IterationShouldBeCorrectOnReversedListWithTwoElements()
        {
            this.Given(s => s.ListWithTwoElementsAccessAplication())
                .When(s => s.Reverse())
                .Then(s => s.ShouldBeSequenceOf(_secondElement, _firstElement))
                .BDDfy();
        }

        [Test]
        public void IterationShouldBeCorrectOnReversedListWithThreeElements()
        {
            this.Given(s => s.ListWithThreeElementsAccessAplication())
                .When(s => s.Reverse())
                .Then(s => s.ShouldBeSequenceOf(_thirdElement, _secondElement, _thirdElement))
                .BDDfy();
        }

        [Test]
        public void ReverseAddFirstToEmptyListLeadsToСorrectLinks()
        {
            this.Given(s => s.EmptyListAccessAplication())
                .When(s => s.Reverse())
                .Then(s => s.ShouldBeDoubleLinkedListWithNodeCountsOf(0))
                .BDDfy();
        }

        [Test]
        public void ReverseAddFirstToListWithOneElementLeadsToCorrectLinks()
        {
            this.Given(s => s.ListWithOneElementAccessAplication())
                .When(s => s.Reverse())
                .Then(s => s.ShouldBeDoubleLinkedListWithNodeCountsOf(1))
                .BDDfy();
        }

        [Test]
        public void ReverseAddFirstToListWithTwoElementsLeadsToCorrectLinks()
        {
            this.Given(s => s.ListWithTwoElementsAccessAplication())
                .When(s => s.Reverse())
                .Then(s => s.ShouldBeDoubleLinkedListWithNodeCountsOf(2))
                .BDDfy();
        }

        [Test]
        public void ReverseOnListWithThreeElementsLeadsToCorrectLinks()
        {
            this.Given(s => s.ListWithThreeElementsAccessAplication())
                .When(s => s.Reverse())
                .Then(s => s.ShouldBeDoubleLinkedListWithNodeCountsOf(3))
                .BDDfy();
        }

        private void EmptyListAccessAplication()
        {
            _doubleLinkedList = new DoubleLinkedList<object>();
        }

        private void ListWithOneElementAccessAplication()
        {
            _firstElement = new object();
            _doubleLinkedList = new DoubleLinkedList<object>();
            _doubleLinkedList.AddLast(_firstElement);
        }

        private void ListWithTwoElementsAccessAplication()
        {
            _firstElement = new object();
            _secondElement = new object();
            _doubleLinkedList = new DoubleLinkedList<object>();
            _doubleLinkedList.AddLast(_firstElement);
            _doubleLinkedList.AddLast(_secondElement);
        }

        private void ListWithThreeElementsAccessAplication()
        {
            _firstElement = new object();
            _secondElement = new object();
            _thirdElement = new object();
            _doubleLinkedList = new DoubleLinkedList<object>();
            _doubleLinkedList.AddLast(_firstElement);
            _doubleLinkedList.AddLast(_secondElement);
            _doubleLinkedList.AddLast(_thirdElement);
        }

        private void CouldReverse()
        {
            Action act = () => _doubleLinkedList.Reverse();
            act.Should().NotThrow();
        }

        private void Reverse()
        {
            _doubleLinkedList.Reverse();
        }

        private void ShouldBeSequenceOf(params object[] elements)
        {
            Enumerable.SequenceEqual(_doubleLinkedList, elements);
        }

        private void ShouldBeDoubleLinkedListWithNodeCountsOf(int requiredNodesCount)
        {
            var nodeCount = 0;
            var pastNode = null as IDoubleLinkedListNode<object>;
            var currentNode = _doubleLinkedList.First;
            while (currentNode != null)
            {
                nodeCount++;
                currentNode.Previous.Should().Be(pastNode);
                pastNode = currentNode;
                currentNode = currentNode.Next;
            }
            var lastNode = pastNode;
            _doubleLinkedList.Last.Should().Be(lastNode);
            nodeCount.Should().Be(requiredNodesCount);
        }
    }
}
