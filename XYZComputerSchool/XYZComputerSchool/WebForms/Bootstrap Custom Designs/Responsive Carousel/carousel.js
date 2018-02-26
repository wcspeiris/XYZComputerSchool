$(document).ready(function(){
	
	function slider(slide,points,arrows,time){
		this.slide = slide;
		this.pointsWrap = points.find('ul');
		this.points = this.pointsWrap.find('li');
		this.count =this.slide.children().length;
		this.cur = 0;
		this.Time = time;
		this.nextCount = 0;
		this.prevCount = this.count-1;
		this.maxlength = this.count*100;
		this.arrows = arrows;
		this.interval = 0;

	};

	//active point reset 
	slider.prototype.pointSelect = function(e,obj){
		this.points.removeClass('active');
		this.points.eq(e).addClass('active');
	};
	
	//automatic slider

	slider.prototype.slideinterval=function(obj){
				this.cur = (this.cur + 1) % this.count;
				length = this.cur*100;
				slide = this.slide;

			slide.animate({'marginLeft':'-'+length+'%'});
			};
	
	//pointsclicking slide
	slider.prototype.pointclicked = function(obj,i){
			var cur = this.points.index(i),
				length = cur*100;
			// alert(cur);
			this.pointSelect(cur);
			this.slide.animate({'marginLeft':'-'+length+'%'});
	};
		
	//effect for the arrows slideing
	slider.prototype.slideEffect = function(e,count){
			var currentSlide = count*100;

		if(e==='next'){

				this.slide.animate({'marginLeft':'-'+currentSlide+'%'});
				this.pointSelect(count);

			};
		if(e==='prev'){

				this.slide.animate({'marginLeft':'-'+currentSlide+'%'});
				this.pointSelect(count);
		};	
	};
	//arrow clicking slide
	slider.prototype.arrowclicked = function(obj,e){
		this.nextCount+=1;
		var direction = $(e).data('dir'),
			max= this.count;
			// alert(direction);
			(this.nextCount<max)?this.nextCount:this.nextCount=0;
			(this.prevCount>-1)?this.prevCount:this.prevCount=max-1;

			(direction==='next')?this.slideEffect('next',this.nextCount):this.slideEffect('prev',this.prevCount);
		
		this.prevCount-=1;
	};

	//rendering all functions
	slider.prototype.render = function(){
		var obj = this,
			tm= obj.Time,
			clear = function(){clearInterval(obj.interval)};
			inter = function(){
						obj.slideinterval(obj);
						obj.pointSelect(obj.cur);
			};
	obj.interval= setInterval(function(){inter()},tm);

	obj.points.on('click',function(){
		index = this;
		obj.pointclicked(obj,index);
		clear();
		obj.interval= setInterval(function(){inter()},tm);
		
	});
	obj.arrows.on('click',function(){
		obj.arrowclicked(obj,this);
		clear();
		obj.interval= setInterval(function(){inter()},tm);
		
	});
	};
	/*
	******************************
	*=object end
	******************************
	*/

	$('.slider').css('overflow','hidden');
	$('body').css('overflow','hidden');

	var carousel = new slider($('.slider'),$('.points'),$('.arrow'),2000);
		carousel.render();
});