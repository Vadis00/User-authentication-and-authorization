import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  constructor() {}

  public columns: number[] =[];
  public rows: number[] =[];
  
  public colorTiles: string[] = ['#ebedf0', '#9be9a8', '#40c463', '#216e39'];

  ngOnInit(): void {
    this.generateHeaderColumn(7);
    this.generateHeaderRow()
    
  }

  public generateHeaderRow(): void {
    var w = window.screen.availWidth;
    const rowElementsCount = w / 15;

    for (let i = 0; i < rowElementsCount-1; i++) {
      this.rows.push(i);
    }

  }

  public generateHeaderColumn(count: number): void{
  
    for (let i = 0; i < count; i++) {
      this.columns.push(i);
    }
 
  }

  public generateRandomColor(): string{ 
   return  this.colorTiles[Math.floor(Math.random() * this.colorTiles.length)];
  }

 
}
