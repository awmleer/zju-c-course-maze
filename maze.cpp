// maze.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"

int maze[10][10];//maze����������¼�Թ�����Ϣ
int route[81][2];//route����������¼�߹���·����Ϣ
int routei=0;

//ɨ����ΧһȦ�Ƿ����
char scan(int x,int y){
	if (maze[x][y + 1] == 0)return 'r';
	if (maze[x+1][y] == 0)return 'd';
	if (maze[x][y-1] == 0)return 'l';
	if (maze[x-1][y] == 0)return 'u';
	return 'n';
}
int next(int x,int y){
	//�ж��Ƿ��ߵ��յ�
	if (x==9 && y==9)
	{
		return 1;//��������յ�ֱ�ӷ���1
	}

	if (maze[x][y+1]==0){//��
		//��¼��һ������Ϣ
		route[routei][0] = x;
		route[routei][1] = y+1;
		routei++;
		maze[x][y + 1]=2;//�Ѹø��ӱ��2
		next(x, y + 1);//�ټ�������һ��
	}
	else if (maze[x + 1][y] == 0){//��
		route[routei][0] = x+1;
		route[routei][1] = y;
		routei++;
		maze[x+1][y] = 2;//�Ѹø��ӱ��2
		next(x + 1, y);
	}
	else if (maze[x][y-1] == 0){//��
		route[routei][0] = x;
		route[routei][1] = y-1;
		routei++;
		maze[x][y - 1] = 2;//�Ѹø��ӱ��2
		next(x, y - 1);
	}
	else if (maze[x-1][y] == 0){//��
		route[routei][0] = x-1;
		route[routei][1] = y;
		routei++;
		maze[x-1][y] = 2;//�Ѹø��ӱ��2
		next(x - 1, y);
	}
	else//��·����
	{
		back(x, y);
	}
}

int back(int x,int y){
	//���route   ֱ����Χ��·������
}

int _tmain(int argc, _TCHAR* argv[])
{

	//��������
	for (i = 0; i<10; i++)
	for (j = 0; j<10; j++)
		scanf("%d", &maze[i][j]);
	//maze������  0��ʾ�ո�  1��ʾǽ  2��ʾ�Ѿ��߹���·��
	
	route[0][0] = 1;
	route[0][1] = 1;


	getchar();
	return 0;
}