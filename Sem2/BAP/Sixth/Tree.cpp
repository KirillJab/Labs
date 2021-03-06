//---------------------------------------------------------------------------

#pragma hdrstop

#include "Tree.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)

Node* Node::Add(Node *node, int num, String str)
{
	if (node == NULL)
	{
		node = new Node;
		node->value = num;
		node->str = str;
		node->left =  NULL;
		node->right = NULL;
	}
	else
	{
		if(num == node->value)
		{
			return node;
		}
		if(num < node->value)
		{
			node->left = Add(node->left, num, str);
		}
		else
		{
			node->right = Add(node->right, num, str);
		}
	}
	return node->Balance(node);
}

unsigned char Node::Height(Node* node)
{
	return node? node->height : 0;
}

int Node::Bfactor(Node* node)
{
	return Height(node->right) - Height(node->left);
}

void Node::Fixheight(Node* node)
{
	unsigned char hleft = Height(node->left);
	unsigned char hright = Height(node->right);
	node->height = (hleft > hright? hleft : hright)+1;
}

Node* Node::RotateRight(Node* node1)
{
	Node* node2 = node1->left;
	node1->left = node2->right;
	node2->right = node1;
	Fixheight(node1);
	Fixheight(node2);
	return node2;
}

Node* Node::RotateLeft(Node* node1)
{
	Node* node2 = node1->right;
	node1->right = node2->left;
	node2->left = node1;
	Fixheight(node2);
	Fixheight(node1);
	return node2;
}

Node* Node::Balance(Node* node)
{
	Fixheight(node);
	if(Bfactor(node) == 2)
	{
		if(Bfactor(node->right) < 0 )
		{
			node->right = RotateRight(node->right);
		}
		return RotateLeft(node);
	}
	if(Bfactor(node) == -2)
	{
		if(Bfactor(node->left) > 0)
		{
			node->left = RotateLeft(node->left);
		}
		return RotateRight(node);
	}
	return node;
}

Node* Node::Find(Node* node, int key)
{
	if(node)
	{
		if(node->value == key)
		{
			return node;
		}
		if(node->value > key)
		{
			return Find(node->left, key);
		}
		return Find(node->right, key);
	}
	return node;
}

Node* Node::MinValueNode(Node* node)
{
	Node* curnode = node;
	while (curnode && curnode->left != NULL)
	{
		curnode = curnode->left;
	}
	return curnode;
}

Node* Node::Delete(Node* node, int key)
{
	if (node == NULL)
	{
		return node;
	}
	if (key < node->value)
	{
		node->left = Delete(node->left, key);
	}
	else if (key > node->value)
	{
		node->right = Delete(node->right, key);
	}
	else
	{
		if (node->left == NULL)
		{
			Node* temp = node->right;
			delete(node);
			return temp;
		}
		else if (node->right == NULL)
		{
			Node* temp = node->left;
			delete(node);
			return temp;
		}

		Node* temp = MinValueNode(node->right);
		node->value = temp->value;
		node->right = Delete(node->right, temp->value);
	}
	return node->Balance(node);
}

int Tree::Task(Node* node)
{
	if (node)
	{
		return 1 + Task(node->left) + Task(node->right);
	}
	return 0;
}
