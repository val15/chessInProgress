``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]       : .NET Framework 4.8 (4.8.4515.0), X86 LegacyJIT
  LegacyJitX64 : .NET Framework 4.8 (4.8.4515.0), X64 LegacyJIT
  LegacyJitX86 : .NET Framework 4.8 (4.8.4515.0), X86 LegacyJIT
  RyuJitX64    : .NET Framework 4.8 (4.8.4515.0), X64 RyuJIT


```
|     Method |          Job |       Jit | Platform |    Mean |    Error |   StdDev |       Gen 0 |       Gen 1 |      Gen 2 | Allocated |
|----------- |------------- |---------- |--------- |--------:|---------:|---------:|------------:|------------:|-----------:|----------:|
| Livel4Bech | LegacyJitX64 | LegacyJit |      X64 | 6.112 s | 0.0930 s | 0.0777 s | 317000.0000 | 122000.0000 | 48000.0000 |  1,624 MB |
| Livel4Bech | LegacyJitX86 | LegacyJit |      X86 | 6.406 s | 0.1280 s | 0.2728 s | 214000.0000 | 139000.0000 | 47000.0000 |    983 MB |
| Livel4Bech |    RyuJitX64 |    RyuJit |      X64 | 6.185 s | 0.0817 s | 0.0724 s | 318000.0000 | 117000.0000 | 49000.0000 |  1,622 MB |
