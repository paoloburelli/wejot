﻿using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using tofy;

namespace Hikae
{
	partial class Catalog : UITableViewSource
	{
		private readonly NSString CellIdentifier = new NSString("Cell");

		public override int RowsInSection (UITableView tableview, int section)
		{
			return Lists.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (UITableViewCell)tableView.DequeueReusableCell (CellIdentifier, indexPath);

			cell.TextLabel.Text = Catalog.Instance.Lists [indexPath.Row].ToString ();

			return cell;
		}

		public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			if (editingStyle == UITableViewCellEditingStyle.Delete) {
				Catalog.Instance.Lists.RemoveAt (indexPath.Row);
				tableView.DeleteRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
				Save ();
			} 
		}

		/*
			// Override to support rearranging the table view.
		public override void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
		{
		}
		*/

		/*
		// Override to support conditional rearranging of the table view.
		public override bool CanMoveRow (UITableView tableView, NSIndexPath indexPath)
		{
			// Return false if you do not want the item to be re-orderable.
			return true;
		}
		*/

		public override string TitleForDeleteConfirmation (UITableView tableView, NSIndexPath indexPath)
		{  
			return "Close";
		}

		public ListSource this[NSIndexPath indexPath]
		{
			get
			{
				return new ListSource (indexPath.Row);
			}
		}
	}
}

