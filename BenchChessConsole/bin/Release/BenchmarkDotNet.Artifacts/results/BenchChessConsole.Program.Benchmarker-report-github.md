``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]       : .NET Framework 4.8 (4.8.4515.0), X86 LegacyJIT
  LegacyJitX64 : .NET Framework 4.8 (4.8.4515.0), X64 LegacyJIT
  LegacyJitX86 : .NET Framework 4.8 (4.8.4515.0), X86 LegacyJIT
  RyuJitX64    : .NET Framework 4.8 (4.8.4515.0), X64 RyuJIT


```
|      Method |          Job |       Jit | Platform |    Mean |   Error |  StdDev |        Gen 0 |        Gen 1 |      Gen 2 | Allocated |
|------------ |------------- |---------- |--------- |--------:|--------:|--------:|-------------:|-------------:|-----------:|----------:|
| Livel4Bench | LegacyJitX64 | LegacyJit |      X64 | 96.87 s | 1.231 s | 1.151 s | 3645000.0000 |  947000.0000 | 41000.0000 |     20 GB |
| Livel4Bench | LegacyJitX86 | LegacyJit |      X86 | 97.74 s | 1.349 s | 1.262 s | 2206000.0000 | 1059000.0000 | 40000.0000 |     12 GB |
| Livel4Bench |    RyuJitX64 |    RyuJit |      X64 | 93.93 s | 1.073 s | 0.951 s | 3644000.0000 |  941000.0000 | 40000.0000 |     20 GB |
