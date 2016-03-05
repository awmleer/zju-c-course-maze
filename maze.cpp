// maze.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"

int maze[10][10];//maze数组用来记录迷宫的信息
int route[81][2];//route数组用来记录走过的路径信息
int routei=0;

//扫描周围一圈是否可走
char scan(int x,int y){
	if (maze[x][y + 1] == 0)return 'r';
	if (maze[x+1][y] == 0)return 'd';
	if (maze[x][y-1] == 0)return 'l';
	if (maze[x-1][y] == 0)return 'u';
	return 'n';
}
int next(int x,int y){
	//判断是否走到终点
	if (x==9 && y==9)
	{
		return 1;//如果到达终点直接返回1
	}

	if (maze[x][y+1]==0){//右
		//记录这一步的信息
		route[routei][0] = x;
		route[routei][1] = y+1;
		routei++;
		maze[x][y + 1]=2;//把该格子标成2
		next(x, y + 1);//再继续走下一步
	}
	else if (maze[x + 1][y] == 0){//下
		route[routei][0] = x+1;
		route[routei][1] = y;
		routei++;
		maze[x+1][y] = 2;//把该格子标成2
		next(x + 1, y);
	}
	else if (maze[x][y-1] == 0){//左
		route[routei][0] = x;
		route[routei][1] = y-1;
		routei++;
		maze[x][y - 1] = 2;//把该格子标成2
		next(x, y - 1);
	}
	else if (maze[x-1][y] == 0){//上
		route[routei][0] = x-1;
		route[routei][1] = y;
		routei++;
		maze[x-1][y] = 2;//把该格子标成2
		next(x - 1, y);
	}
	else//无路可走
	{
		back(x, y);
	}
}

int back(int x,int y){
	//清除route   直到周围有路可以走
}

int _tmain(int argc, _TCHAR* argv[])
{

	//输入数据
	for (i = 0; i<10; i++)
	for (j = 0; j<10; j++)
		scanf("%d", &maze[i][j]);
	//maze数组中  0表示空格  1表示墙  2表示已经走过的路径
	
	route[0][0] = 1;
	route[0][1] = 1;


	getchar();
	return 0;
}