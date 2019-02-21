using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using TestStack.BDDfy;

namespace DoubleLinkedListTask.Core.Specs.DoubleLinkedList
{
    public class AddElementSpecs
    {
        private IDoubleLinkedList<object> _doubleLinkedList;
        private object _firstElement;
        private object _secondElement;
        private object _thirdElement;
        private object _addedElement;

        [Test]
        public void CouldAddFirstToEmptyList()
        {
            this.Given(s => s.EmptyListAccessAplication())
                .Then(s => s.CouldAddFirst())
                .BDDfy();
        }

        [Test]
        public void CouldAddLastToEmptyList()
        {
            this.Given(s => s.EmptyListAccessAplication())
                .Then(s => s.CouldAddLast())
                .BDDfy();
        }

        [Test]
        public void CouldAddFirstToListWithOneElement()
        {
            this.Given(s => s.ListWithOneElementAccessAplication())
                .Then(s => s.CouldAddFirst())
                .BDDfy();
        }

        [Test]
        public void CouldAddLastToListWithOneElement()
        {
            this.Given(s => s.ListWithOneElementAccessAplication())
                .Then(s => s.CouldAddLast())
                .BDDfy();
        }

        [Test]
        public void CouldAddFirstToListWithTwoElements()
        {
            this.Given(s => s.ListWithTwoElementsAccessAplication())
                .Then(s => s.CouldAddFirst())
                .BDDfy();
        }

        [Test]
        public void CouldAddLastToListWithTwoElements()
        {
            this.Given(s => s.ListWithTwoElementsAccessAplication())
                .Then(s => s.CouldAddLast())
                .BDDfy();
        }

        [Test]
        public void CouldAddFirstToListWithThreeElements()
        {
            this.Given(s => s.ListWithThreeElementsAccessAplication())
                .Then(s => s.CouldAddFirst())
                .BDDfy();
        }

        [Test]
        public void CouldAddLastToListWithThreeElements()
        {
            this.Given(s => s.ListWithThreeElementsAccessAplication())
                .Then(s => s.CouldAddLast())
                .BDDfy();
        }

        [Test]
        public void AddFirstToEmptyListLeadsToCorrectSequence()
        {
            this.Given(s => s.EmptyListAccessAplication())
                .When(s => s.AddFirst(_addedElement))
                .Then(s => s.ShouldBeSequenceOf(_addedElement))
                .BDDfy();
        }

        [Test]
        public void AddLastToEmptyListLeadsToCorrectSequence()
        {
            this.Given(s => s.EmptyListAccessAplication())
                .When(s => s.AddLast(_addedElement))
                .Then(s => s.ShouldBeSequenceOf(_addedElement))
                .BDDfy();
        }

        [Test]
        public void AddFirstToListWithOneElementLeadsToCorrectSequence()
        {
            this.Given(s => s.ListWithOneElementAccessAplication())
                .When(s => s.AddFirst(_addedElement))
                .Then(s => s.ShouldBeSequenceOf(_addedElement, _firstElement))
                .BDDfy();
        }

        [Test]
        public void AddLastToListWithOneElementLeadsToCorrectSequence()
        {
            this.Given(s => s.ListWithOneElementAccessAplication())
                .When(s => s.AddLast(_addedElement))
                .Then(s => s.ShouldBeSequenceOf(_firstElement, _addedElement))
                .BDDfy();
        }

        [Test]
        public void AddFirstToListWithTwoElementsLeadsToCorrectSequence()
        {
            this.Given(s => s.ListWithTwoElementsAccessAplication())
                .When(s => s.AddFirst(_addedElement))
                .Then(s => s.ShouldBeSequenceOf(_addedElement, _firstElement, _secondElement))
                .BDDfy();
        }

        [Test]
        public void AddLastToListWithTwoElementsLeadsToCorrectSequence()
        {
            this.Given(s => s.ListWithTwoElementsAccessAplication())
                .When(s => s.AddLast(_addedElement))
                .Then(s => s.ShouldBeSequenceOf(_firstElement, _secondElement, _addedElement))
                .BDDfy();
        }

        [Test]
        public void AddFirstToListWithThreeElementsLeadsToCorrectSequence()
        {
            this.Given(s => s.ListWithThreeElementsAccessAplication())
                .When(s => s.AddFirst(_addedElement))
                .Then(s => s.ShouldBeSequenceOf(_addedElement, _firstElement, _secondElement, _thirdElement))
                .BDDfy();
        }

        [Test]
        public void AddLastToListWithThreeElementsLeadsToCorrectSequence()
        {
            this.Given(s => s.ListWithThreeElementsAccessAplication())
                .When(s => s.AddLast(_addedElement))
                .Then(s => s.ShouldBeSequenceOf(_firstElement, _secondElement, _thirdElement, _addedElement))
                .BDDfy();
        }

        [Test]
        public void AddFirstToEmptyListLeadsToСorrectLinks()
        {
            this.Given(s => s.EmptyListAccessAplication())
                .When(s => s.AddFirst(_addedElement))
                .Then(s => s.ShouldBeDoubleLinkedListWithNodeCountsOf(1))
                .BDDfy();
        }

        [Test]
        public void AddLastToEmptyListLeadsToCorrectLinks()
        {
            this.Given(s => s.EmptyListAccessAplication())
                .When(s => s.AddLast(_addedElement))
                .Then(s => s.ShouldBeDoubleLinkedListWithNodeCountsOf(1))
                .BDDfy();
        }

        [Test]
        public void AddFirstToListWithOneElementLeadsToCorrectLinks()
        {
            this.Given(s => s.ListWithOneElementAccessAplication())
                .When(s => s.AddFirst(_addedElement))
                .Then(s => s.ShouldBeDoubleLinkedListWithNodeCountsOf(2))
                .BDDfy();
        }

        [Test]
        public void AddLastToListWithOneElementLeadsToCorrectLinks()
        {
            this.Given(s => s.ListWithOneElementAccessAplication())
                .When(s => s.AddLast(_addedElement))
                .Then(s => s.ShouldBeDoubleLinkedListWithNodeCountsOf(2))
                .BDDfy();
        }

        [Test]
        public void AddFirstToListWithTwoElementsLeadsToCorrectLinks()
        {
            this.Given(s => s.ListWithTwoElementsAccessAplication())
                .When(s => s.AddFirst(_addedElement))
                .Then(s => s.ShouldBeDoubleLinkedListWithNodeCountsOf(3))
                .BDDfy();
        }

        [Test]
        public void AddLastToListWithTwoElementsLeadsToCorrectLinks()
        {
            this.Given(s => s.ListWithTwoElementsAccessAplication())
                .When(s => s.AddLast(_addedElement))
                .Then(s => s.ShouldBeDoubleLinkedListWithNodeCountsOf(3))
                .BDDfy();
        }

        [Test]
        public void AddFirstToListWithThreeElementsLeadsToCorrectLinks()
        {
            this.Given(s => s.ListWithThreeElementsAccessAplication())
                .When(s => s.AddFirst(_addedElement))
                .Then(s => s.ShouldBeDoubleLinkedListWithNodeCountsOf(4))
                .BDDfy();
        }

        [Test]
        public void AddLastToListWithThreeElementsLeadsToCorrectLinks()
        {
            this.Given(s => s.ListWithThreeElementsAccessAplication())
                .When(s => s.AddLast(_addedElement))
                .Then(s => s.ShouldBeDoubleLinkedListWithNodeCountsOf(4))
                .BDDfy();
        }

        private void EmptyListAccessAplication()
        {
            _addedElement = new object();
            _doubleLinkedList = new DoubleLinkedList<object>();
        }

        private void ListWithOneElementAccessAplication()
        {
            _addedElement = new object();
            _firstElement = new object();
            _doubleLinkedList = new DoubleLinkedList<object>();
            _doubleLinkedList.AddLast(_firstElement);
        }

        private void ListWithTwoElementsAccessAplication()
        {
            _addedElement = new object();
            _firstElement = new object();
            _secondElement = new object();
            _doubleLinkedList = new DoubleLinkedList<object>();
            _doubleLinkedList.AddLast(_firstElement);
            _doubleLinkedList.AddLast(_secondElement);
        }

        private void ListWithThreeElementsAccessAplication()
        {
            _addedElement = new object();
            _firstElement = new object();
            _secondElement = new object();
            _thirdElement = new object();
            _doubleLinkedList = new DoubleLinkedList<object>();
            _doubleLinkedList.AddLast(_firstElement);
            _doubleLinkedList.AddLast(_secondElement);
            _doubleLinkedList.AddLast(_thirdElement);
        }

        private void CouldAddFirst()
        {
            Action act = () => _doubleLinkedList.AddFirst(new object());
            act.Should().NotThrow();
        }

        private void CouldAddLast()
        {
            Action act = () => _doubleLinkedList.AddLast(new object());
            act.Should().NotThrow();
        }

        private void AddFirst(object element)
        {
            _doubleLinkedList.AddFirst(element);
        }

        private void AddLast(object element)
        {
            _doubleLinkedList.AddLast(element);
        }

        private void ShouldBeSequenceOf(params object[] elements)
        {
            Enumerable.SequenceEqual(_doubleLinkedList, elements).Should().BeTrue();
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
