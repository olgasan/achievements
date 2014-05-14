using UnityEngine;
using System.Collections;

public class OnScreenDebugMenu  
{
	private const int BTN_X = 10;
	private const int BTN_Y = 10;
	
	private const int BTN_W = 100;
	private const int BTN_H = 40;
	
	private Rect rect;
	private int col;
	private int row;

	public OnScreenDebugMenu ()
	{
		Reset ();
	}

	public void Reset ()
	{
		col = 0;
		row = 0;
	}

	public void AdvanceCol ()
	{
		row = 0;
		col++;
	}
	
	public bool DrawButton (string label)
	{
		UpdateRect ();
		return GUI.Button (rect, label);
	}

	public void DrawLabel (string label)
	{
		UpdateRect ();
		GUI.Label (rect, label);
	}

	private void UpdateRect ()
	{
		int y = BTN_Y + (BTN_H * row);
		int x = BTN_X + (BTN_W * col);
		rect = new Rect (x, y, BTN_W, BTN_H);
		row++;
	}
}
