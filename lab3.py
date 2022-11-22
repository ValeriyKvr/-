class DoublyLinkedListNode:
    def __init__(self, value, previous, next):
        self.value = value
        self.previous = previous
        self.next = next

class DoublyLinkedList:
    head = None
    tail = None

    def insert_begin(self, value):
        if self.head is None:
            node = DoublyLinkedListNode(value, None, None)
            self.head = node
            self.tail = node
        else:
            node = DoublyLinkedListNode(value, None, self.head)
            self.head.previous = node
            self.head = node

    def insert_end(self, value):
        if self.tail is None:
            node = DoublyLinkedListNode(value, None, None)
            self.tail = node
            self.head = node
        else:
            node = DoublyLinkedListNode(value, self.tail, None)
            self.tail.next = node
            self.tail = node

    def remove_begin(self):
        if self.head is None:
            return None

        result = self.head.value

        if self.head == self.tail:
            self.head = None
            self.tail = None
        else:
            self.head = self.head.next
            self.head.previous = None

        return result

    def fore(self):
        current = self.head
        while current is not None:
            yield current.value
            current = current.next


lst = DoublyLinkedList()
lst.insert_begin(1)
lst.insert_begin(2)
lst.insert_begin(3)
lst.insert_begin(4)
lst.insert_end(5)

print(sum(lst.fore()))
