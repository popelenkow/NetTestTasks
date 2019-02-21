using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using TestStack.BDDfy;

namespace DoubleLinkedListTask.Core.Specs.DoubleLinkedList
{
    class AddElementSpecs
    {
        private IDoubleLinkedList<object> _doubleLinkedList;
        private object _firstElement;
        private object _secondElement;
        private object _thirdElement;



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

        private void ShouldBeDoubleLinkedListWithNodesCountsOf(int requiredNodesCount)
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
