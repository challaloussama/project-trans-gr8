﻿namespace TransGr8_DD_Test
{
	public class SpellChecker
	{
		private readonly List<Spell> _spellList;

		public SpellChecker(List<Spell> spells)
		{
			_spellList = spells;
		}

		public bool CanUserCastSpell(User user, string spellName)
		{
			Spell spell = _spellList.Find(s => s.Name == spellName);
			
			// No need to specify spells in my tests , if i doesn't exist it will return false
			if(spell == null)
			{
				return false;
			}
			if (user.Level < spell.Level)
			{
				return false;
			}
			if (spell.Components.Contains("V"))
			{
				if (!user.HasVerbalComponent)
				{
					return false;
				}
			}
			if (spell.Components.Contains("S"))
			{
				if (!user.HasSomaticComponent)
				{
					return false;
				}
			}
			if (spell.Components.Contains("M"))
			{
				if (!user.HasMaterialComponent)
				{
					return false;
				}
			}
			if (user.Range < spell.Range)
			{
				return false;
			}
			if (spell.Duration.Contains("Concentration"))
			{
				if (!user.HasConcentration)
				{
					return false;
				}
			}
			if (spell.Name.Equals("Cure Wounds"))
			{
				if (!user.HasSomaticComponent)
				{
					return false;
				}
			}
            if (user.Level < spell.Level)
            {
                return false;
            }
            if (!user.HasConcentration)
            {
                return false;
            }
            // Add additional checks as needed for specific saving throws or other requirements.
            return true;
		}
		
	}
}
