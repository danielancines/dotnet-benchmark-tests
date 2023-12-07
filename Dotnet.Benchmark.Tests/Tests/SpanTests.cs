using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser]
public class SpanTests
{
    [Params("Emp,Vch,Hre,3GG,s2A,jCs,qsX,OSq,Xwz,S5A,33E,k3f,8E0,uUX,0ub,Zax,VSt,Fb5,H5e,gqk,Hmn,ePG,X3s,3Nu,pqR,e6d,sMU,b7M,0MD,3ux,4RH,2Sj,z60,g1B,0gC,TjP,p44,9Or,2cT,c4f,ytN,a4u,sQ9,kYH,Ue2,7em,J9a,KJp,uve,fGD,C3y,eyv,M6z,zjA,Q6Y,oKb,p1u,xzQ,sCb,RUE,C4b,Z1f,xRJ,gNJ,Xyj,EGw,K88,GXt,atg,VHD,tQO,zoY,h8k,O3O,YAV,B7R,g70,Tmb,UGW,mYW,oqe,aU9,s0X,T3P,G12,ubu,QfS,BbX,UzS,Ezc,fkX,G2Z,o2o,emd,wjp,wrk,4u9,7Jk,vCx,4GZ",
            "FeP,zOF,GgQ,WvS,HJm,w25,8wS,nRM,02B,4H2,JeW,P7g,dYW,Fd4,yoJ,cwr,CJg,7S0,gcS,MWj,H7T,arm,z3x,pEW,Pf0,63T,aav,Umr,fTY,aSg,cvg,d7P,4Oc,UAj,CXt,PFM,7sK,dbQ,C9Q,e6o,D4p,8jr,UCt,eyK,P9z,hub,qsy,z9Y,fvZ,Fj1,gwj,XQw,D7f,hx2,FRv,p8P,afP,upS,9m2,c9q,FJk,gT1,Nap,2H0,X32,owZ,yA9,NvH,rU0,Gte,tWa,ers,Ygs,xOn,ZNP,Axd,nG4,OJm,WBG,KNx,O5y,GMo,8zA,mPt,fYZ,seu,Xaj,MBX,KZX,cmc,4Fw,vcu,TmP,Yf3,aap,TgV,ogP,gnR,w9Y,Z3k")]
    public string Value { get; set; }

    [Benchmark(Baseline = true)]
    public void ConventionalSplit()
    {
        var splittedValues = Value.Split(',');

        var dto = new MyDto()
        {
            Value1 = splittedValues[0] + splittedValues[1] + splittedValues[2],
            Value2 = splittedValues[1] + splittedValues[1] + splittedValues[2],
            Value3 = splittedValues[2] + splittedValues[1] + splittedValues[2],
            Value4 = splittedValues[3] + splittedValues[1] + splittedValues[2]
        };
    }

    [Benchmark]
    public void UsingSpans()
    {
        var spanValues = Value.AsSpan();

        var dto = new MyDtoSpan()
        {
            Value1 = spanValues.Slice(0,3),
            Value2 = spanValues.Slice(0,3),
            Value3 = spanValues.Slice(0,3),
            Value4 = spanValues.Slice(0,3)
        };
    }
}

public class MyDto
{
    public string Value1 { get; set; }
    public string Value2 { get; set; }
    public string Value3 { get; set; }
    public string Value4 { get; set; }
}

public ref struct MyDtoSpan
{
    public ReadOnlySpan<char> Value1 { get; set; }
    public ReadOnlySpan<char> Value2 { get; set; }
    public ReadOnlySpan<char> Value3 { get; set; }
    public ReadOnlySpan<char> Value4 { get; set; }
}
