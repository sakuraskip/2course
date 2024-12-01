#include "stdafx.h"
#include "Parm.h"
namespace Parm
{
	PARM getparm(int argc, _TCHAR* argv[])
	{
		PARM parm;
		bool parmIn =0 , parmOut = 0, parmLog =0;
		for (int i = 1; i < argc; i++)
		{
			if (wcslen(argv[i]) > PARM_MAX_SIZE)
			{
				throw ERROR_THROW(104);
			}
			if (wcsstr(argv[i], PARM_IN))
			{
				parmIn = true;
				wcscpy_s(parm.in, argv[i]+wcslen(PARM_IN));// для сдвига чтобы скопировать только название файла
			}
			if (wcsstr(argv[i], PARM_OUT))
			{
				parmOut = true;
				wcscpy_s(parm.out, argv[i]+wcslen(PARM_OUT));
			}
			if (wcsstr(argv[i], PARM_LOG))
			{
				parmLog = true;
				wcscpy_s(parm.log, argv[i]+wcslen(PARM_LOG));
			}
		}
		if (parmIn == false)
		{
			throw ERROR_THROW(100);
		}
		if (parmOut == false)
		{
			wcscpy_s(parm.out, parm.in);
			wcscat_s(parm.out, PARM_OUT_DEFAULT_EXT);
		}
		if (parmLog == false)
		{
			wcscpy_s(parm.log, parm.in);
			wcscat_s(parm.log, PARM_LOG_DEFAULT_EXT);
		}
		return parm;
	}
}