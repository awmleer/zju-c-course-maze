// maze.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"

int next(){

}

int back(){

}

int _tmain(int argc, _TCHAR* argv[])
{
	int maze[10][10];//maze数组用来记录迷宫的信息
	int route[81][2];//route数组用来记录走过的路径信息
	for (i = 0; i<10; i++)
	for (j = 0; j<10; j++)
		scanf("%d", &maze[i][j]);
	//maze数组中  0表示空格  1表示墙  2表示已经走过的路径
	

	getchar();
	return 0;
}