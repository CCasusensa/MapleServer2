function getFirstScriptId()
    local jobId = Helper.GetPlayerJobId()
    if jobId == 1 then
        return 10
    elseif jobId == 60 then
        return 20
    elseif jobId < 60 then
        return jobId + 20
    end
    return jobId + 10
end