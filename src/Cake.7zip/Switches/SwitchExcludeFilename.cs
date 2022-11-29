using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// -x (Exclude filenames) switch.
/// </para>
/// <para>
/// Specifies which filenames or wildcard-names must be excluded from the operation.
/// Multiple exclude switches are supported.
/// </para>
/// <para>
/// <list type="bullet">
/// <item><description><see cref="ISupportSwitchExcludeFilenames"/></description></item>
/// <item><description><see cref="SwitchExcludeFilenamesBuilder"/></description></item>
/// <item><description><see cref="SwitchExcludeFilenameCollection"/></description></item>
/// </list>
/// </para>
/// <seealso cref="ISwitch" />
/// </summary>
public class SwitchExcludeFilename : ISwitch
{
    private readonly string wildcard;
    private readonly RecurseType? recurseType;

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchExcludeFilename"/> class.
    /// </summary>
    /// <param name="wildcard">The wildcard.</param>
    /// <param name="recurseType">Type of the recurse.</param>
    public SwitchExcludeFilename(string wildcard, RecurseType? recurseType = null)
    {
        this.wildcard = wildcard;
        this.recurseType = recurseType;
    }

    /// <inheritdoc/>
    public void BuildArguments(ref ProcessArgumentBuilder builder)
    {
        var recurse = recurseType == null ? string.Empty : $"r{recurseType}";
        builder.Append($"-x{recurse}!{wildcard}");
    }
}