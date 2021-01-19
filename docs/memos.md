# メモ / Memo

----

## branch命令のオペランドの値

branch命令のオペランドは、そのオペランドの終端位置からのバイトオフセット値である。

## Value of operand of branch instaructions

The operands of branch instaructions mean the byte offset from the terminal of its instruction.

## branch命令のオペランドサイズ解決

branch命令のオペランドサイズ(1 or 4byte)は参照先ラベルのバイトオフセットに依存する。
そのためオペランドサイズの解決にはILストリーム全体をチェックする必要がある。

判定ルーチンは以下の通り。

1. 対象ラベルが未マークであれば常に4byteとする

2. 対象ラベルがマーク済ならバイトオフセットを計算する

   - 参照ラベルがbranch命令よりも後にある場合、間にあるオペレーションの
     バイトサイズをそのまま加算したものをバイトオフセットとする

   - 参照ラベルがbranch命令よりも前にある場合、branch命令と参照ラベルの間にある
     すべてのbranch命令を4byte版とみなしてバイトサイズを加算する。
     オペランドサイズ判定ルーチンの無限再起呼び出しを抑止するため

3. 得られたバイトオフセットが`sbyte`の範囲内なら1byteと、そうでないなら4byteとする

コードは`PowerEmit.Emit.BranchOperation.GetOperandSize`メソッド参照。

## Resolving an operand size of branch instructions

Branch instructions' operand sizes (1 or 4 byte) are depend on byte offset to reference label.

So we have to check IL stream overall to resolve operand size.

Followings are determination routine.

1. If reference label has not be marked yet, always we regard operand size as 4 byte.

2. If reference label has be marked, we calculate byte offset to the label.

   - If reference label is after the branch instruction,
     we get byte offset by natural sum of operations between them.

   - If reference label is before the branch instruction,
     we get byte offset by sum of operations between them with the condition:
     all of other branch instructions are 4 byte version.
     This is to inhibit infinite recursive call of determination routine.

3. We regard operand size as 1 byte if obtained byte offset is in `sbyte` range;
   otherwise 4 byte.

Reference `PowerEmit.Emit.BranchOperation.GetOperandSize`.

----
