#include "stdio.h"
#include "stdlib.h"


struct Sample
{
    float x, depth, velocity;
};

void push(struct Sample* samples, struct Sample sample, int *i, int *capacity)
{
    if( *i > *capacity)
        {
            realloc(samples, *capacity * sizeof(struct Sample));
            *capacity *= 2;
        }
    samples[*i++] = sample;
}

void sort(struct Sample* samples, int i)
{
    int j = 0, k;

    for(; j < i; j++)
    {
        for(k = j + 1; k < i; k++)
        {
            if(samples[j].x > samples[k].x)
            {
                struct Sample sample; 
                sample =  samples[j];
                samples[j] = samples[k];
                samples[k] = sample; 
            }
        }
    }
}


int main()
{
    struct Sample* samples = malloc(3 * sizeof(struct Sample)); 
    int i = 0, capacity = 2;
    float prevX, prevVelocity, prevDepth, depth, velocity, volume;
 
    while(1)    
    {
        
        struct Sample sample;
        printf("\n\nThis is your sample #%d.\nPlease, ENTER the DISTANCE from the left bank of the river: ", i+1);
        while (1)
        {    
            scanf("%f", &sample.x);
            if (sample.x < 0)
                printf("the DISTANCE can't be negative!\nPlease, try again: ");
            else
                break;
        }
        printf("Please, ENTER the DEPTH of the river: ");
        scanf("%f", &sample.depth);
        printf("Please, ENTER the VELOCITY of the river flow: ");
        scanf("%f", &sample.velocity);
        i++;
        push(samples, sample, &i, &capacity);
        if(i>2)
        {
            printf("\n\nIf you REACHED THE OTHER BANK of the river, please, PRESS SPACE. Otherwise press any other button.\n\n");
            if (getch() == ' ')
            {
                    break;
            }
        }
    }
    
    prevX = 0;
    prevVelocity = 0;
    prevDepth = 0;
    sort(samples, i);
    int j = 0;
    for(; j < i; j++)
    {
        float dx;

        dx = samples[j].x - prevX ;
        depth = (prevDepth + samples[j].depth) / 2 * dx;
        velocity = (prevVelocity +  samples[j].velocity) / 2 * dx;
        prevX =  samples[j].x;
        prevVelocity =  samples[j].velocity;
        prevDepth =  samples[j].depth;
        if(dx > 0)
        {
            volume += depth * velocity / dx;
        }
        else
        {
            volume += 0;
        }
    }
    printf("\n\nVolume per second = %f", volume);
}