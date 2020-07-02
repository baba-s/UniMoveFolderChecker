using UnityEditor;

namespace Kogane.Internal
{
	internal sealed class MoveFolderChecker : UnityEditor.AssetModificationProcessor
	{
		private static AssetMoveResult OnWillMoveAsset( string sourcePath, string destinationPath )
		{
			var isFolder = AssetDatabase.IsValidFolder( sourcePath );

			if ( !isFolder ) return AssetMoveResult.DidNotMove;

			var message = $"{sourcePath} フォルダを\n{destinationPath} に移動しますか？";

			var isOk = EditorUtility.DisplayDialog
			(
				title: "フォルダ移動",
				message: message,
				ok: "OK",
				cancel: "キャンセル"
			);

			return isOk ? AssetMoveResult.DidNotMove : AssetMoveResult.FailedMove;
		}
	}
}