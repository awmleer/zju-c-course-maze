// maze.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"

int maze[10][10];//maze����������¼�Թ�����Ϣ
int route[81][2];//route����������¼�߹���·����Ϣ
int routei=0;

char scan(int x, int y);
void next(int x, int y);
void back();


//ɨ����ΧһȦ�Ƿ����
char scan(int x,int y){
	if (maze[x][y + 1] == 0)return 'r';
	if (maze[x+1][y] == 0)return 'd';
	if (maze[x][y-1] == 0)return 'l';
	if (maze[x-1][y] == 0)return 'u';
	printf("SCAN and result n:%d,%d\n", x, y);
	return 'n';
}
void next(int x,int y){
	printf("get to:%d,%d\n", x, y);
	//�ж��Ƿ��ߵ��յ�
	if (x==8 && y==8)
	{
		printf("end!\n");
		return;//��������յ�ֱ�ӷ���1
	}

	if (maze[x][y+1]==0){//��
		//��¼��һ������Ϣ
		routei++;
		route[routei][0] = x;
		route[routei][1] = y+1;
		maze[x][y + 1]=2;//�Ѹø��ӱ��2
		next(x, y + 1);//�ټ�������һ��
	}
	else if (maze[x + 1][y] == 0){//��
		routei++;
		route[routei][0] = x+1;
		route[routei][1] = y;
		maze[x+1][y] = 2;
		next(x + 1, y);
	}
	else if (maze[x][y-1] == 0){//��
		routei++;
		route[routei][0] = x;
		route[routei][1] = y-1;
		maze[x][y - 1] = 2;
		next(x, y - 1);
	}
	else if (maze[x-1][y] == 0){//��
		routei++;
		route[routei][0] = x-1;
		route[routei][1] = y;
		maze[x-1][y] = 2;
		next(x - 1, y);
	}
	else//��·����
	{
		back();
	}
}

void back(){
	//routei����  ֱ����Χ��·������
	do
	{
		routei--;
		printf("  back:%d,%d\n", route[routei][0], route[routei][1]);
	} while (scan(route[routei][0],route[routei][1])=='n');
	//����������
	next(route[routei][0], route[routei][1]);
}

int _tmain(int argc, _TCHAR* argv[])
{

	//��������
	for (int i = 0; i<10; i++)
	for (int j = 0; j<10; j++)
		scanf_s("%d", &maze[i][j]);
	//maze������  0��ʾ�ո�  1��ʾǽ  2��ʾ�Ѿ��߹���·��
	
	//��ʼ��route
	route[0][0] = 1;
	route[0][1] = 1;

	//��1,1��ʼ��
	next(1, 1);

	//���·��
	for (int i = 0; i <= routei; i++)
	{
		printf("(%d,%d)\n", route[i][0], route[i][1]);
	}

	getchar();
	getchar();

	return 0;
}