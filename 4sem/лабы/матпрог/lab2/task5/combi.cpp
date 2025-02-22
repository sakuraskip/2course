#include "knap.h"
#define NINF 0x80000000    // ����� ����� int-�����  
namespace combi
{
    subset::subset(short n)
    {
        this->n = n;
        this->sset = new short[n];
        this->reset();
    };
    void subset::reset()
    {
        this->sn = 0;
        this->mask = 0;
    };
    short subset::getfirst()
    {
        __int64 buf = this->mask;
        this->sn = 0;
        for (short i = 0; i < n; i++)
        {
            if (buf & 0x1) this->sset[this->sn++] = i;
            buf >>= 1;
        }
        return this->sn;
    };
    short subset::getnext()
    {
        int rc = -1;
        this->sn = 0;
        if (++this->mask < this->count()) rc = getfirst();
        return rc;
    };
    short subset::ntx(short i)
    {
        return  this->sset[i];
    };
    unsigned __int64 subset::count()
    {
        return (unsigned __int64)(1 << this->n);
    };
};
int calcv(combi::subset s, const int v[])  // ����� � �������
{
    int rc = 0;
    for (int i = 0; i < s.sn; i++) rc += v[s.ntx(i)];
    return rc;
};
int calcc(combi::subset s, const int v[], const int c[]) //��������� � ������� 
{
    int rc = 0;
    for (int i = 0; i < s.sn; i++) rc += (v[s.ntx(i)] * c[s.ntx(i)]);
    return rc;
};
void setm(combi::subset s, short m[]) //�������� ��������� �������� 
{
    for (int i = 0; i < s.n; i++) m[i] = 0;
    for (int i = 0; i < s.sn; i++) m[s.ntx(i)] = 1;
};
int   knapsack_s(
    int V,         // [in] ����������� ������� 
    short n,       // [in] ���������� ����� ��������� 
    const int v[], // [in] ������ �������� ������� ����  
    const int c[], // [in] ��������� �������� ������� ����
    short  m[]     // [out] ���������� ��������� ������� ���� {0,1} 
)
{
    combi::subset s(n);
    int maxc = NINF, cc = 0;
    short  ns = s.getfirst();
    while (ns >= 0)
    {
        if (calcv(s, v) <= V)
            if ((cc = calcc(s, v, c)) > maxc)
            {
                maxc = cc;
                setm(s, m);
            }
        ns = s.getnext();
    };
    return maxc;
};

