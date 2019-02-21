using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using TestStack.BDDfy;

namespace DoubleLinkedListTask.Core.Specs.DoubleLinkedList
{
    public class EnumerableSpecs
    {
        private IDoubleLinkedList<object> _doubleLinkedList;
        private object _firstElement;
        private object _secondElement;
        private object _thirdElement;

        [Test]
        public void CouldIterateOnEmptyList()
        {
            this.Given(s => s.EmptyListAccessAplication())
                .Then(s => s.CouldIterate())
                .BDDfy();
        }

        [Test]
        public void CouldIterateOnListWithOneElement()
        {
            this.Given(s => s.ListWithOneElementAccessAplication())
                .Then(s => s.CouldIterate())
                .BDDfy();
        }

        [Test]
        public void CouldIterateOnListWithTwoElements()
        {
            this.Given(s => s.ListWithTwoElementsAccessAplication())
                .Then(s => s.CouldIterate())
                .BDDfy();
        }

        [Test]
        public void CouldIterateOnListWithThreeElements()
        {
            this.Given(s => s.ListWithThreeElementsAccessAplication())
                .Then(s => s.CouldIterate())
                .BDDfy();
        }

        [Test]
        public void IterationShouldBeCorrectOnEmptyList()
        {
            this.Given(s => s.EmptyListAccessAplication())
                .Then(s => s.ShouldBeSequenceOf())
                .BDDfy();
        }

        [Test]
        public void IterationShouldBeCorrectOnListWithOneElement()
        {
            this.Given(s => s.ListWithOneElementAccessAplication())
                .Then(s => s.ShouldBeSequenceOf(_firstElement))
                .BDDfy();
        }

        [Test]
        public void IterationShouldBeCorrectOnListWithTwoElements()
        {
            this.Given(s => s.ListWithTwoElementsAccessAplication())
                .Then(s => s.ShouldBeSequenceOf(_firstElement, _secondElement))
                .BDDfy();
        }

        [Test]
        public void IterationShouldBeCorrectOnListWithThreeElements()
        {
            this.Given(s => s.ListWithThreeElementsAccessAplication())
                .Then(s => s.ShouldBeSequenceOf(_firstElement, _secondElement, _thirdElement))
                .BDDfy();
        }

        [Test]
        public void EnumerableShouldBeEqualsDoubleLinkedListOnEmptyList()
        {
            this.Given(s => s.EmptyListAccessAplication())
                .Then(s => s.EnumerableShouldBeEqualsDoubleLinkedList())
                .BDDfy();
        }

        [Test]
        public void EnumerableShouldBeEqualsDoubleLinkedListOnListWithOneElement()
        {
            this.Given(s => s.ListWithOneElementAccessAplication())
                .Then(s => s.EnumerableShouldBeEqualsDoubleLinkedList())
                .BDDfy();
        }

        [Test]
        public void EnumerableShouldBeEqualsDoubleLinkedListOnListWithTwoElements()
        {
            this.Given(s => s.ListWithTwoElementsAccessAplication())
                .Then(s => s.EnumerableShouldBeEqualsDoubleLinkedList())
                .BDDfy();
        }

        [Test]
        public void EnumerableShouldBeEqualsDoubleLinkedListOnListWithThreeElements()
        {
            this.Given(s => s.ListWithThreeElementsAccessAplication())
                .Then(s => s.EnumerableShouldBeEqualsDoubleLinkedList())
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

        private void CouldIterate()
        {
            Action act = () =>
            {
                foreach (var element in _doubleLinkedList)
                {
                }
            };
            act.Should().NotThrow();
        }

        private void ShouldBeSequenceOf(params object[] elements)
        {
            Enumerable.SequenceEqual(_doubleLinkedList, elements);
        }

        private void EnumerableShouldBeEqualsDoubleLinkedList()
        {
            var enumerableNode = _doubleLinkedList.GetEnumerator();
            var doubleLinkedListNode = _doubleLinkedList.First;
            while (enumerableNode.MoveNext())
            {
                enumerableNode.Current.Should().Be(doubleLinkedListNode.Value);
                doubleLinkedListNode = doubleLinkedListNode.Next;
            }
            doubleLinkedListNode.Should().Be(null);
        }
    }
}
