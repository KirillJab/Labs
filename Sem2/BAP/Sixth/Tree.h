//---------------------------------------------------------------------------
#include <string.h>

using namespace std;

#ifndef TreeH
#define TreeH
//---------------------------------------------------------------------------

class Node
{
	public:
	unsigned char height;
	int value;
	String str;
	Node* left;
	Node* right;

	Node()
	{
		height = 1;
	};
	Node(int key, String str)
	{
		height = 1;
		this->value = key;
		this->str = str;
	};
	~Node(){};
	Node* Add(Node*, int, String);
	unsigned char Height(Node*);
	int Bfactor(Node*);
	void Fixheight(Node*);
	Node* Balance(Node*);
	Node* RotateRight(Node*);
	Node* RotateLeft(Node*);
	Node* Find(Node*, int);
	Node* Delete(Node*, int);
	private:
	Node* MinValueNode(Node*);
};

class Tree : public Node
{
	public:
	Tree() : Node(){};
	Tree(int key, String str) : Node(key, str){};
	static int Task(Node*);
};

#endif
