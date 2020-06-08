import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Bottlecap } from '../../../../shared/models';
import { SpaceService } from '../space.service';

@Component({
  selector: 'app-space-area',
  templateUrl: './space-area.component.html',
  styleUrls: ['./space-area.component.css']
})
export class SpaceAreaComponent implements OnInit {
	@ViewChild('bottlecap', { static: true })
	canvas: ElementRef<HTMLCanvasElement>;
  constructor(private spaceService: SpaceService) { }

	private ctx: CanvasRenderingContext2D;

	ngOnInit(): void {
		this.spaceService.getSpaceBottlecaps();
  }

	placeBottlecap(title) {
		this.ctx = this.canvas.nativeElement.getContext('2d');
		this.ctx.arc(50, 50, 40, 0, 2 * Math.PI);
		this.ctx.stroke();
		//this.ctx.font = "30px Arial";
		this.ctx.fillText(title, 10, 50);
	}

	checkSpaces() {
		console.log("spaces: ", this.spaceService.spaceBottleCapCollection);
	}
}
