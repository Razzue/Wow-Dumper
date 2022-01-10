# Wow-Dumper
A simple wow offset dumper.

# _Class()
• `string? Name;` -> The output name of the class. Anything non alphanumeric will be regexed out, and spaces replaced with '_'.
<br> • `string[]? Comments;` => Not currently hooked up. Will add comments before a class in the CodeDom writer.
<br> • `_Offset[]> Offsets;` => Collection of offset classes.

# _Offset()
• `string? Name;` -> The output name of the field. Anything non alphanumeric will be regexed out, and spaces replaced with '_'.
<br> • `string? Pattern;` -> Pattern to scan memory for. All wildcards must be `??`.
<br> • `string? Comment;` -> Not currently hooked up. Will add comment after value in CodeDom writer.
<br> • `int Position;` -> Index + 1 of the last byte before the first wildcard(s) you're scanning for. Will automate this eventually.
<br> • `int Modifier;` -> Any additional values that should be added to located IntPtr.
<br> • `bool MinusOne;` -> Subtract one from the located pointer of the offset. Should be left true in 99% of uses.
<br> • `_Level[]? Levels;` -> Extra levels to scan through. Offset will reflect end result.
<br> • `_Field[]? Fields;` -> Extra fields that can be grabbed from the patterns location.

# _Level()
• `int Position;` -> Index + 1 of the last byte before the first wildcard(s) you're scanning for.
<br> • `bool MinusOne;` -> Subtract one from the located pointer of the offset. Should be left true in 99% of uses.

# _Field()
• `ReadType Type;` -> Defines how many bytes the scanner reads for the field (1, 2, 4, 8, 10, 25, or 50).
<br> • `int Position;` -> Index + 1 of the last byte before the first wildcard(s) you're scanning for. Will automate this eventually.
<br> • `string? Name;` -> The output name of the field. Anything non alphanumeric will be regexed out, and spaces replaced with '_'.
<br> • `string? Comment;` -> Not currently hooked up. Will add comment after value in CodeDom writer.

<br>Donations always welcome <3 
<br>BTC   -> bc1q22p5q8dnw2ldzwk3c8eyp7mn7spng2wepg6hgr
<br>Eth   -> 0xd6A688E2Bd8EEB7E75e570A5F82585a42eAe2373
<br>Doge  -> DPu3BhbXUJPBYeDScVuLmue1kbSJRSpnoL
