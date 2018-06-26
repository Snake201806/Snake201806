﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake201806.Model
{
    /// <summary>
    /// Az irányított kígyót reprezentáló osztály
    /// </summary>
    class Snake
    {
        public Snake(int rowPosition, int columnPosition)
        {
            HeadPosition = new ArenaPosition(rowPosition, columnPosition);
            HeadDirection = SnakeHeadDirectionEnum.InPlace;
            Length = 6;
            //gondoskodom arról, hogy a lista változóm listát tartalmazzon, 
            //nehogy object reference null hibára fussunk
            //http://netacademia.blog.hu/tags/null_object_pattern
            Tail = new List<ArenaPosition>();
        }

        //tudnia kell, hogy hol van a kígyó feje
        public ArenaPosition HeadPosition { get; set; }

        //tudnia kell, hogy merre megy éppen
        public SnakeHeadDirectionEnum HeadDirection { get; set; }

        //tudnia kell, hogy milyen hosszú

        /// <summary>
        /// Ehhez nyilván kell tartanunk a kígyó farkának pontjait, 
        /// amit egy listában célszerű megtenni
        /// </summary>
        public List<ArenaPosition> Tail { get; set; }

        public int Length { get; set; }


        //két property: a kígyó farok vége, és a nyaka, ami az eleje.



    }
}