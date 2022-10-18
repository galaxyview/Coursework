#include<stdio.h>
#include<stdlib.h>
#include<unistd.h>


int main(){
    pid_t pid;
    pid = fork();

    if(pid == -1)
        perror("Fail to fork!\n");
    else if(pid == 0){
        printf("正在运行子进程B(%i)\n",getpid());
        exit(0);
    }else{
        pid = fork();
        if(pid == -1)
            perror("Fail to fork!\n");
        else if (pid == 0)
        {
            printf("正在运行子进程C(%i)\n",getpid());
            exit(0);
        }
        printf("正在运行父进程A(%i)\n",getpid());
        exit(0);
    }
}

